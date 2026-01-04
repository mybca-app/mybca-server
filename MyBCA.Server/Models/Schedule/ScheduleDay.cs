namespace MyBCA.Server.Models.Schedule;

public class ScheduleDay
{
    public int Id { get; set; }
    public DateOnly Day { get; set; }
    public int ScheduleId { get; set; }
    public Schedule? Schedule { get; set; } = null;
}