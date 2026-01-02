using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Services.News;
using MyBCA.Shared.Models.News.Responses;
using MyBCA.Shared.Models.News;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors("AllowAll")]
public class NewsController(INewsService newsService) : ControllerBase
{
    [EndpointSummary("Retrieves the latest news story")]
    [HttpGet]
    public async Task<ActionResult<NewsApiResponse<NewsStory>>> Latest()
    {
        var story = await newsService.GetLatestStoryAsync();

        return Ok(new NewsApiResponse<NewsStory>(story, newsService.Expiry));
    }

    [EndpointSummary("Retrieves the top 10 latest news stories")]
    [HttpGet]
    public async Task<ActionResult<NewsApiResponse<NewsStory>>> List()
    {
        var stories = await newsService.GetLatestStoriesAsync();

        return Ok(new NewsApiResponse<IEnumerable<NewsStory>>(stories, newsService.Expiry));
    }
}