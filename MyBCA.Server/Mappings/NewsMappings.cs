using MyBCA.Server.Dtos.News;
using MyBCA.Server.Models.News;

namespace MyBCA.Server.Mappings;

public static class NewsMappings
{
    public static NewsStoryDto ToDto(this NewsStory story)
    {
        return new NewsStoryDto(
            Title: story.Title,
            Link: story.Link,
            ImageLink: story.ImageLink,
            CreatedAt: story.CreatedAt
        );
    }
}