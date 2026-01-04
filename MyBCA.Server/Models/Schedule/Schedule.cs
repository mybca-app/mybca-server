namespace MyBCA.Server.Models.Schedule;

public class Schedule
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required List<ScheduleItem> Items { get; set; } = [];
}