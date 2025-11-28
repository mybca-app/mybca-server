
using System.Text.RegularExpressions;
using MyBCA.Server.Services.Bus;

namespace MyBCA.Server.Services.Notifications;

public partial class DailyBusNotificationService(FcmService fcmService, IBusService busService, ILogger<DailyBusNotificationService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextRun = new DateTime(now.Year, now.Month, now.Day, 16, 10, 00);

            if (now > nextRun || now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                nextRun = nextRun.AddDays(1);
                while (nextRun.DayOfWeek == DayOfWeek.Saturday || nextRun.DayOfWeek == DayOfWeek.Sunday)
                    nextRun = nextRun.AddDays(1);
            }

            var delay = nextRun - now;
            logger.LogInformation("Next notification wave scheduled at {NextRun}", nextRun);
            await Task.Delay(delay, stoppingToken);

            var buses = await busService.GetPositionsAsync();
            foreach (var position in buses)
            {
                var normalizedTown = Regex.Replace(position.Town.ToLower(), "[^a-zA-Z0-9-_.~%]", "-");
                var topic = $"bus-subscribed-{normalizedTown}";
                var title = position.Location == ""
                    ? $"{position.Town} hasn't arrived yet"
                    : $"{position.Town} is boarding in {position.Location}";

                await fcmService.SendMessageAsync(topic, title, "Open the myBCA app for more bus info.");
            }
        }
    }
}