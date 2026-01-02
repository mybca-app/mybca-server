using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MyBCA.Server.Models;
using MyBCA.Shared.Models.News;
using WordPressPCL;

namespace MyBCA.Server.Services.News;

public class NewsService(IOptions<NewsOptions> options, ILogger<NewsService> logger, IMemoryCache cache, HttpClient httpClient) : INewsService
{
    private readonly WordPressClient _wordpressClient = new(httpClient);

    private const string CacheKey = "NewsStories";

    public DateTime? Expiry
    {
        get
        {
            if (cache.TryGetValue<CacheItem<IEnumerable<NewsStory>>>(CacheKey, out var cachedStories))
            {
                return cachedStories!.Expiry;
            }

            return null;
        }
    }

    public async Task<IEnumerable<NewsStory>> GetLatestStoriesAsync()
    {
        if (cache.TryGetValue<CacheItem<IEnumerable<NewsStory>>>(CacheKey, out var cachedStories))
        {
            logger.LogDebug("Using cached news data");
            return cachedStories!.Value;
        }

        logger.LogDebug("Fetching new news data");

        var wpPosts = await _wordpressClient.Posts.QueryAsync(new WordPressPCL.Utility.PostsQueryBuilder
        {
            Page = 1,
            PerPage = 10,
        });

        var stories = await Task.WhenAll(wpPosts.Select(async post =>
        {
            var media = post.FeaturedMedia.HasValue && post.FeaturedMedia.Value > 0
                ? await _wordpressClient.Media.GetByIDAsync(post.FeaturedMedia) : null;

            return new NewsStory(
                post.Title.Rendered, post.Link, media?.SourceUrl, post.DateGmt
            );
        }));

        var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(options.Value.CacheTtl);
        cache.Set(CacheKey, new CacheItem<IEnumerable<NewsStory>>
        {
            Value = stories,
            Expiry = DateTime.Now + options.Value.CacheTtl
        }, cacheEntryOptions);

        return stories;
    }

    public async Task<NewsStory> GetLatestStoryAsync()
    {
        var latestList = await GetLatestStoriesAsync();
        return latestList.First();
    }
}