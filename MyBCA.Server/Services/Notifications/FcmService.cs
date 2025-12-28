using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;

namespace MyBCA.Server.Services.Notifications;

public class FcmService
{
    private readonly FirebaseMessaging? _messaging;
    private readonly ILogger<FcmService> _logger;
    private readonly IOptions<FcmOptions> _options;

    public FcmService(ILogger<FcmService> logger, IOptions<FcmOptions> options)
    {
        _options = options;
        if (_options.Value.NotificationsEnabled)
        {
            var app = FirebaseApp.DefaultInstance ?? FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.GetApplicationDefault()
            });

            _messaging = FirebaseMessaging.GetMessaging(app);
        }
        else
        {
            logger.LogInformation("Not setting up Firebase because notifications are disabled.");
        }
        _logger = logger;
    }

    public async Task SendMessageAsync(string topic, string title, string body)
    {
        if (!_options.Value.NotificationsEnabled)
        {
            return;
        }

        var message = new Message
        {
            Topic = topic,
            Notification = new Notification
            {
                Title = title,
                Body = body
            }
        };

        try
        {
            var response = await _messaging!.SendAsync(message);
            _logger.LogInformation("FCM sent: {Response}", response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending FCM");
        }
    }
}