using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MyBCA.Server.Models;
using MyBCA.Server.Models.News;
using WordPressPCL;
using WordPressPCL.Models;

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

    private async Task<string?> GetFeaturedImageUrlAsync(Post post)
    {
        if (post.FeaturedMedia is > 0)
        {
            try
            {
                var media = await _wordpressClient.Media.GetByIDAsync(post.FeaturedMedia);
                return media?.SourceUrl;
            }
            catch (Exception ex)
            {
                logger.LogDebug(
                    ex,
                    "Failed to load featured media for post {PostId}",
                    post.Id
                );
            }
        }

        return null;
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

        var stories = await Task.WhenAll(
            wpPosts.Select(async post =>
            {
                var mediaUrl = await GetFeaturedImageUrlAsync(post);

                return new NewsStory(
                    Id: post.Id,
                    Title: post.Title.Rendered,
                    Link: post.Link,
                    ImageLink: mediaUrl,
                    ContentHtml: null,
                    CreatedAt: post.DateGmt
                );
            })
        );


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

    public async Task<NewsStory?> GetStoryById(int id)
    {
        var post = await _wordpressClient.Posts.GetByIDAsync(id);
        if (post is null)
        {
            return null;
        }

        var mediaUrl = await GetFeaturedImageUrlAsync(post);
        return new NewsStory(
            Id: post.Id,
            Title: post.Title.Rendered,
            Link: post.Link,
            ImageLink: mediaUrl,
            ContentHtml: post.Content.Rendered,
            CreatedAt: post.DateGmt
        );
    }
}