namespace MyBCA.Server.Dtos.Nutrislice;

public record MenuItemDto(
    DateTime? Date,
    int Position,
    bool IsSectionTitle,
    string? Text,
    FoodItemDto Food,
    uint StationID,
    bool IsStationHeader,
    string? Image,
    string? Category
);