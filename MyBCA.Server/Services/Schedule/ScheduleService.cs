namespace MyBCA.Server.Services.Schedule;

using Microsoft.EntityFrameworkCore;
using MyBCA.Server.Data;
using MyBCA.Server.Models.Schedule;

public class ScheduleService(AppDbContext db) : IScheduleService
{
    public async Task<ScheduleDay?> GetScheduleDayAsync(DateOnly date)
    {
        ScheduleDay? schedule = await db.ScheduleDays
            .Include(s => s.Schedule)
            .SingleOrDefaultAsync(s => s.Day == date);

        return schedule;
    }
}