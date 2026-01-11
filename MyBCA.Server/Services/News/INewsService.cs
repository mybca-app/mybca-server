using MyBCA.Server.Models.News;

namespace MyBCA.Server.Services.News;

public interface INewsService
{
    Task<IEnumerable<NewsStory>> GetLatestStoriesAsync();
    Task<NewsStory> GetLatestStoryAsync();
    Task<NewsStory?> GetStoryById(int id);
    DateTime? Expiry { get; }
}