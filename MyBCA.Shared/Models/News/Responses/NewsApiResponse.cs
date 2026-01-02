namespace MyBCA.Shared.Models.News.Responses;

public record NewsApiResponse<T>(T Data, DateTime? Expiry);