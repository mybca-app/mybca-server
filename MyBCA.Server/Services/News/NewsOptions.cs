namespace MyBCA.Server.Services.News;

public class NewsOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public TimeSpan CacheTtl { get; set; } = TimeSpan.Zero;
}
