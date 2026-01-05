namespace MyBCA.Server.Models.News.Responses;

public record NewsApiResponse<T>(T Data, DateTime? Expiry);