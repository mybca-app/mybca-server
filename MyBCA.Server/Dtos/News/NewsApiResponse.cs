namespace MyBCA.Server.Dtos.News;

public record NewsApiResponse<T>(T Data, DateTime? Expiry);