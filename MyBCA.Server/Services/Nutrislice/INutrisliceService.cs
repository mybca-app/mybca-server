using MyBCA.Server.Dtos.Nutrislice;

namespace MyBCA.Server.Services.Nutrislice;

public interface INutrisliceService
{
    Task<MenuWeekDto> GetMenuWeekAsync();
    Task<MenuDayDto?> GetMenuDayAsync();
    DateTime? Expiry { get; }
}
