namespace MyBCA.Server.Dtos.News;

public record NewsStoryDto(
    string Title,
    string Link,
    string? ImageLink,
    DateTime CreatedAt
);