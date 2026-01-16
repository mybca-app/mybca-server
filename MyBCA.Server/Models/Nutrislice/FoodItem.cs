using System.Text.Json.Serialization;

namespace MyBCA.Server.Models.Nutrislice;

public record FoodItem(
    int Id,
    string? Name,
    string? Description,
    string? Subtext,
    string? ImageUrl,
    [property: JsonPropertyName("rounded_nutrition_info")] FoodItemNutritionInfo? NutritionInfo
);