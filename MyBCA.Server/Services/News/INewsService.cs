using MyBCA.Server.Models.News;

namespace MyBCA.Server.Services.News;

public interface INewsService
{
    Task<IEnumerable<NewsStory>> GetLatestStoriesAsync();
    Task<NewsStory> GetLatestStoryAsync();
    DateTime? Expiry { get; }
}