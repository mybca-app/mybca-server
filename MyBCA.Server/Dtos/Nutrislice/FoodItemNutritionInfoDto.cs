namespace MyBCA.Server.Dtos.Nutrislice;

public record FoodItemNutritionInfoDto(
    double? Calories,
    double? Fat,
    double? SaturatedFat,
    double? TransFat,
    double? Cholesterol,
    double? Carbs,
    double? AddedSugar,
    double? Sugar,
    double? Potassium,
    double? Sodium,
    double? Fiber,
    double? Protein,
    double? Iron,
    double? Calcium,
    double? VitaminC,
    double? VitaminA,
    double? RetinolEquivalents,
    double? MicrogramsVitaminA,
    double? VitaminD,
    double? MicrogramsVitaminD
);
