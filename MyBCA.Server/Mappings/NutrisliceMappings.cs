using MyBCA.Server.Dtos.Nutrislice;
using MyBCA.Server.Models.Nutrislice;

namespace MyBCA.Server.Mappings;

public static class NutrisliceMappings
{
    public static FoodItemNutritionInfoDto ToDto(this FoodItemNutritionInfo info)
    {
        return new FoodItemNutritionInfoDto(
            info.Calories,
            info.Fat,
            info.SaturatedFat,
            info.TransFat,
            info.Cholesterol,
            info.Carbs,
            info.AddedSugar,
            info.Sugar,
            info.Potassium,
            info.Sodium,
            info.Fiber,
            info.Protein,
            info.Iron,
            info.Calcium,
            info.VitaminC,
            info.VitaminA,
            info.RetinolEquivalents,
            info.MicrogramsVitaminA,
            info.VitaminD,
            info.MicrogramsVitaminD
        );
    }

    public static FoodItemDto ToDto(this FoodItem item)
    {
        return new FoodItemDto(
            Id: item.Id,
            Name: item.Name,
            Description: item.Description,
            Subtext: item.Subtext,
            ImageUrl: item.ImageUrl,
            NutritionInfo: item.NutritionInfo?.ToDto()
        );
    }

    public static MenuItemDto ToDto(this MenuItem item)
    {
        return new MenuItemDto(
            Date: item.Date,
            Position: item.Position,
            IsSectionTitle: item.IsSectionTitle,
            Text: item.Text,
            Food: item.Food?.ToDto(),
            StationID: item.StationID,
            IsStationHeader: item.IsStationHeader,
            Image: item.Image,
            Category: item.Category
        );
    }

    public static MenuDayDto ToDto(this MenuDay day)
    {
        return new MenuDayDto(
            Date: day.Date,
            MenuItems: day.MenuItems.Select(item => item.ToDto())
        );
    }

    public static MenuWeekDto ToDto(this MenuWeek week)
    {
        return new MenuWeekDto(
            StartDate: week.StartDate,
            DisplayName: week.DisplayName,
            Days: week.Days.Select(day => day.ToDto())
        );
    }
}
