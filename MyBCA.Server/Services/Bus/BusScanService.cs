
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using MyBCA.Server.Models.Bus;
using MyBCA.Server.Services.Notifications;

namespace MyBCA.Server.Services.Bus;

public partial class BusScanService(IServiceProvider services, FcmService fcmService, HttpClient httpClient, IOptions<BusOptions> options, ILogger<BusScanService> logger) : BackgroundService
{
    public string? SourceUrl => options.Value.BaseUrl;

    private Dictionary<string, string>? _positionMap;
    private DateTime? _dismissalEndTime;

    private List<BusPositionChange> GetPositionChanges(Dictionary<string, string> newPositionMap)
    {
        var changes = new List<BusPositionChange>();

        foreach (var (newKey, newValue) in newPositionMap)
        {
            // Don't notify when the spreadsheet is being cleared.
            if (string.IsNullOrWhiteSpace(newValue))
            {
                logger.LogDebug("Position change: {Town} (ignoring because new value is empty)", newKey);
                continue;
            }

            if (_positionMap != null && _positionMap.TryGetValue(newKey, out string? oldValue))
            {
                if (oldValue != newValue)
                {
                    logger.LogDebug("Position change: {Town} :: {Old} -> {New}", newKey, oldValue, newValue);
                    changes.Add(new BusPositionChange(newKey, oldValue, newValue));
                }
            }
            else
            {
                logger.LogDebug("Position change: {Town} :: (not present) -> {New}", newKey, newValue);
                changes.Add(new BusPositionChange(newKey, "", newValue));
            }
        }

        return changes;
    }

    private async Task SendPositionChangeNotif(BusPositionChange positionChange)
    {
        var normalizedTown = Regex.Replace(positionChange.Town.ToLower(), "[^a-zA-Z0-9-_.~%]", "-");
        var topic = $"bus-subscribed-{normalizedTown}";
        var title = $"{positionChange.NewPosition}: {positionChange.Town} just arrived";

        logger.LogDebug("Sending bus notification: {Topic}: {Title}", topic, title);
        await fcmService.SendMessageAsync(topic, title, "Open the myBCA app for more bus info.");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var now = DateTime.Now;

                var html = await httpClient.GetStringAsync("", stoppingToken);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var newPositionMap = BusSheetReader.ParseTableToPositionMap(doc);
                var changes = GetPositionChanges(newPositionMap);


                if (changes.Count > 0)
                {
                    if (_dismissalEndTime == null)
                    {
                        _dismissalEndTime = now.AddMinutes(30);
                        logger.LogInformation("Detected dismissal time - dismissal window ends at {EndTime}.", _dismissalEndTime);
                    }
                }

                if (_dismissalEndTime != null && now >= _dismissalEndTime)
                {
                    _dismissalEndTime = null;
                }

                if (changes.Count > 0)
                {
                    _dismissalEndTime = now.AddMinutes(30);
                }

                var nextRun =
                    _dismissalEndTime != null
                        ? now.AddSeconds(15)
                        : now.AddMinutes(5);

                if (nextRun.DayOfWeek == DayOfWeek.Saturday || nextRun.DayOfWeek == DayOfWeek.Sunday)
                {
                    nextRun = nextRun.AddDays(1);
                    while (nextRun.DayOfWeek == DayOfWeek.Saturday || nextRun.DayOfWeek == DayOfWeek.Sunday)
                        nextRun = nextRun.AddDays(1);
                }

                logger.LogDebug("Next run: {NextRun}", nextRun);

                if (_positionMap is not null)
                {
                    foreach (var change in changes)
                    {
                        using (var scope = services.CreateScope())
                        {
                            var busLogService = scope.ServiceProvider.GetRequiredService<IBusArrivalService>();
                            await busLogService.CreateArrivalAsync(change.Town, change.NewPosition);
                        }
                        await SendPositionChangeNotif(change);
                    }
                }

                _positionMap = newPositionMap;

                var delay = nextRun - DateTime.Now;
                if (delay < TimeSpan.Zero)
                {
                    delay = TimeSpan.Zero;
                }

                await Task.Delay(delay, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "BusNotifService encountered an error in ExecuteAsync loop.");
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}