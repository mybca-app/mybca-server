namespace MyBCA.Server.Dtos.Nutrislice;

public record MenuWeekDto(
    string? StartDate,
    string? DisplayName,
    IEnumerable<MenuDayDto> Days
);