namespace MyBCA.Server.Dtos.Nutrislice;

public record FoodItemDto(
    int Id,
    string? Name,
    string? Description,
    string? Subtext,
    string? ImageUrl
);