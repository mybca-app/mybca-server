namespace MyBCA.Server.Models.News;

public record NewsStory(
    int Id,
    string Title,
    string Link,
    string? ImageLink,
    string? ContentHtml,
    DateTime CreatedAt
);