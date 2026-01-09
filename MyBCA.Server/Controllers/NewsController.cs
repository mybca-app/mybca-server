using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Services.News;
using MyBCA.Server.Dtos.News;
using MyBCA.Server.Models.News;
using MyBCA.Server.Mappings;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors("AllowAll")]
public class NewsController(INewsService newsService) : ControllerBase
{
    [EndpointSummary("Retrieves the latest news story")]
    [HttpGet]
    public async Task<ActionResult<NewsApiResponse<NewsStoryDto>>> Latest()
    {
        var story = await newsService.GetLatestStoryAsync();

        return Ok(new NewsApiResponse<NewsStoryDto>(story.ToDto(), newsService.Expiry));
    }

    [EndpointSummary("Retrieves the top 10 latest news stories")]
    [HttpGet]
    public async Task<ActionResult<NewsApiResponse<IEnumerable<NewsStoryDto>>>> List()
    {
        var stories = await newsService.GetLatestStoriesAsync();

        return Ok(
            new NewsApiResponse<IEnumerable<NewsStoryDto>>(
                stories.Select(s => s.ToDto()),
                newsService.Expiry
            )
        );
    }
}