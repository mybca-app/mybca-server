namespace MyBCA.Server.Dtos.Nutrislice;

public record NutrisliceApiResponse<T>(T Data, DateTime? Expiry);