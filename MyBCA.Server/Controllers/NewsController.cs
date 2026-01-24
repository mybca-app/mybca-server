using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Services.News;
using MyBCA.Server.Dtos.News;
using MyBCA.Server.Models.News;
using MyBCA.Server.Mappings;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/news")]
[EnableCors("AllowAll")]
public class NewsController(INewsService newsService) : ControllerBase
{
    [EndpointSummary("Retrieves the latest news story")]
    [HttpGet("stories/latest")]
    public async Task<ActionResult<NewsApiResponse<NewsStoryDto>>> Latest()
    {
        var story = await newsService.GetLatestStoryAsync();

        return Ok(new NewsApiResponse<NewsStoryDto>(story.ToDto(), newsService.Expiry));
    }

    [EndpointSummary("Retrieves the top 10 latest news stories")]
    [HttpGet("stories")]
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

    [EndpointSummary("Retrieves a story by its ID")]
    [HttpGet("stories/{id}")]
    public async Task<ActionResult<NewsStoryDto?>> ById(int id)
    {
        var story = await newsService.GetStoryById(id);

        if (story is null)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                type: $"/errors/StoryNotFound",
                title: "Resource Not Found",
                detail: "Story for the given ID not found.",
                instance: HttpContext.Request.Path
            );
        }

        return Ok(story);
    }
}