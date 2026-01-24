namespace MyBCA.Server.Services.Schedule;

using MyBCA.Server.Dtos.Schedule;

public interface IScheduleService
{
    Task<ScheduleDayDto?> GetScheduleDayAsync(DateOnly date);
}