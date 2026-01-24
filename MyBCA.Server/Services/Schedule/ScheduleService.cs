namespace MyBCA.Server.Services.Schedule;

using Microsoft.EntityFrameworkCore;
using MyBCA.Server.Data;
using MyBCA.Server.Dtos.Schedule;
using MyBCA.Server.Mappings;
using MyBCA.Server.Models.Schedule;

public class ScheduleService(AppDbContext db) : IScheduleService
{
    public async Task<ScheduleDayDto?> GetScheduleDayAsync(DateOnly date)
    {
        ScheduleDay? schedule = await db.ScheduleDays
            .Include(s => s.Schedule)
            .SingleOrDefaultAsync(s => s.Day == date);

        return schedule?.ToDto();
    }
}