namespace MyBCA.Server.Dtos.Schedule;

public record ScheduleDayDto(
    int Id,
    DateOnly Day,
    int ScheduleId,
    ScheduleDto? Schedule
);