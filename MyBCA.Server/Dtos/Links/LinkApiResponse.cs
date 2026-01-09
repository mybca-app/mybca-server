namespace MyBCA.Server.Dtos.Links;

public record LinkApiResponse(int Count, IEnumerable<LinkDto> Data);