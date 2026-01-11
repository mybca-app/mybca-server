namespace MyBCA.Server.Dtos.News;

public record NewsStoryDto(
    int Id,
    string Title,
    string Link,
    string? ImageLink,
    string? ContentHtml,
    DateTime CreatedAt
);