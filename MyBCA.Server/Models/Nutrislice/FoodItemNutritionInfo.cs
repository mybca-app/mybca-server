using System.Text.Json.Serialization;

namespace MyBCA.Server.Models.Nutrislice;

public record FoodItemNutritionInfo(
    [property: JsonPropertyName("calories")] double? Calories,
    [property: JsonPropertyName("g_fat")] double? Fat,
    [property: JsonPropertyName("g_saturated_fat")] double? SaturatedFat,
    [property: JsonPropertyName("g_trans_fat")] double? TransFat,
    [property: JsonPropertyName("mg_cholesterol")] double? Cholesterol,
    [property: JsonPropertyName("g_carbs")] double? Carbs,
    [property: JsonPropertyName("g_added_sugar")] double? AddedSugar,
    [property: JsonPropertyName("g_sugar")] double? Sugar,
    [property: JsonPropertyName("mg_potassium")] double? Potassium,
    [property: JsonPropertyName("mg_sodium")] double? Sodium,
    [property: JsonPropertyName("g_fiber")] double? Fiber,
    [property: JsonPropertyName("g_protein")] double? Protein,
    [property: JsonPropertyName("mg_iron")] double? Iron,
    [property: JsonPropertyName("mg_calcium")] double? Calcium,
    [property: JsonPropertyName("mg_vitamin_c")] double? VitaminC,
    [property: JsonPropertyName("iu_vitamin_a")] double? VitaminA,
    [property: JsonPropertyName("re_vitamin_a")] double? RetinolEquivalents,
    [property: JsonPropertyName("mcg_vitamin_a")] double? MicrogramsVitaminA,
    [property: JsonPropertyName("mg_vitamin_d")] double? VitaminD,
    [property: JsonPropertyName("mcg_vitamin_d")] double? MicrogramsVitaminD
);
