namespace MyBCA.Server.Dtos.Nutrislice;

public record MenuDayDto(
    string? Date,
    IEnumerable<MenuItemDto> MenuItems
);