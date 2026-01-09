namespace MyBCA.Server.Dtos.Schedule;

public record ScheduleItemDto(
    string PeriodName,
    TimeOnly StartTime,
    TimeOnly EndTime
);