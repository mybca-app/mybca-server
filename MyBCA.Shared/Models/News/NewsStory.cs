namespace MyBCA.Shared.Models.News;

public record NewsStory(
    string Title,
    string Link,
    string? ImageLink,
    DateTime CreatedAt
);