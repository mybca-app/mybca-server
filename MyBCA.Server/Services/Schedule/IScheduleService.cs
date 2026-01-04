namespace MyBCA.Server.Services.Schedule;

using MyBCA.Server.Models.Schedule;

public interface IScheduleService
{
    Task<ScheduleDay?> GetScheduleDayAsync(DateOnly date);
}