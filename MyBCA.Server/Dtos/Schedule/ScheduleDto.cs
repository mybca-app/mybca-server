namespace MyBCA.Server.Dtos.Schedule;

public record ScheduleDto(
    int Id,
    string Name,
    List<ScheduleItemDto> Items
);