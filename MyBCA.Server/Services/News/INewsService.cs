using MyBCA.Server.Dtos.News;

namespace MyBCA.Server.Services.News;

public interface INewsService
{
    Task<IEnumerable<NewsStoryDto>> GetLatestStoriesAsync();
    Task<NewsStoryDto> GetLatestStoryAsync();
    Task<NewsStoryDto?> GetStoryById(int id);
    DateTime? Expiry { get; }
}