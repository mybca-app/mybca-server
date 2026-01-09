using MyBCA.Server.Dtos.Schedule;
using MyBCA.Server.Models.Schedule;

namespace MyBCA.Server.Mappings;

public static class ScheduleMappings
{
    public static ScheduleItemDto ToDto(this ScheduleItem item)
    {
        return new ScheduleItemDto(
            PeriodName: item.PeriodName,
            StartTime: item.StartTime,
            EndTime: item.EndTime
        );
    }

    public static ScheduleDto ToDto(this Schedule sched)
    {
        return new ScheduleDto(
            Id: sched.Id,
            Name: sched.Name,
            Items: [.. sched.Items.Select(item => item.ToDto())]
        );
    }

    public static ScheduleDayDto ToDto(this ScheduleDay day)
    {
        return new ScheduleDayDto(
            Id: day.Id,
            Day: day.Day,
            ScheduleId: day.ScheduleId,
            Schedule: day.Schedule?.ToDto()
        );
    }
}