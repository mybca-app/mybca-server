using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace MyBCA.Server.Services.Notifications;

public class FcmService
{
    private readonly FirebaseMessaging _messaging;
    private readonly ILogger<FcmService> _logger;

    public FcmService(ILogger<FcmService> logger)
    {
        var app = FirebaseApp.DefaultInstance ?? FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.GetApplicationDefault()
        });
        
        _logger = logger;
        _messaging = FirebaseMessaging.GetMessaging(app);
    }

    public async Task SendMessageAsync(string topic, string title, string body)
    {
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
            var response = await _messaging.SendAsync(message);
            _logger.LogInformation("FCM sent: {Response}", response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending FCM");
        }
    }
}