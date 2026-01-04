namespace MyBCA.Server.Models.Schedule;

public class ScheduleItem
{
    public required string PeriodName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}