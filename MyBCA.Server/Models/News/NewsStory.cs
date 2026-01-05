namespace MyBCA.Server.Models.News;

public record NewsStory(
    string Title,
    string Link,
    string? ImageLink,
    DateTime CreatedAt
);