namespace MyBCA.Server.Models.Links.Responses;

public record LinkApiResponse(int Count, IEnumerable<Link> Data);