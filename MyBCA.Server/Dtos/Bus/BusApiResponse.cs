namespace MyBCA.Server.Dtos.Bus;

public record BusApiResponse(int Count, Dictionary<string, string> Data, DateTime? Expiry);