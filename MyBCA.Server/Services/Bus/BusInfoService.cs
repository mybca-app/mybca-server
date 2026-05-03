using Microsoft.EntityFrameworkCore;
using MyBCA.Server.Data;
using MyBCA.Server.Dtos.Bus;
using MyBCA.Server.Mappings;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public class BusInfoService(AppDbContext db) : IBusInfoService
{
    public async Task<BusArrivalDto> CreateArrivalAsync(string bus, string location)
    {
        var log = new BusArrival
        {
            BusName = bus,
            BusPosition = location
        };

        db.BusArrivals.Add(log);
        await db.SaveChangesAsync();

        return log.ToDto();
    }

    public async Task<IEnumerable<BusArrivalDto>> GetArrivalsByBusAsync(string bus)
    {
        return await db.BusArrivals
            .Where(a => a.BusName == bus)
            .OrderByDescending(a => a.ArrivalTime)
            .Select(a => a.ToDto())
            .ToListAsync();
    }

    public async Task<IEnumerable<BusArrivalDto>> GetArrivalsAsync(
        DateOnly? start = null,
        DateOnly? end = null)
    {
        IQueryable<BusArrival> query = db.BusArrivals;

        if (start.HasValue)
        {
            query = query.Where(a =>
                a.ArrivalTime >= start.Value.ToDateTime(TimeOnly.MinValue));
        }

        if (end.HasValue)
        {
            query = query.Where(a =>
                a.ArrivalTime <= end.Value.ToDateTime(TimeOnly.MaxValue));
        }

        return await query
            .OrderByDescending(a => a.ArrivalTime)
            .Select(a => a.ToDto())
            .ToListAsync();
    }

    public async Task<BusInfoDto?> GetInfoByBusAsync(string bus)
    {
        var averageArrival = await GetAverageArrivalTimeAsync(bus);

        return await db.BusInfos
            .Where(i => i.Name == bus)
            .Include(i => i.Company)
            .Select(i => i.ToDto(averageArrival))
            .FirstOrDefaultAsync();
    }

    public async Task<TimeOnly?> GetAverageArrivalTimeAsync(string bus)
    {
        var result = await db.Database
            .SqlQueryRaw<TimeSpan?>(@"
            SELECT SEC_TO_TIME(
                AVG(TIME_TO_SEC(TIME(CONVERT_TZ(ArrivalTime, 'UTC', 'America/New_York'))))
            ) AS Value
            FROM BusArrivals
            WHERE BusName = {0}
                AND TIME(CONVERT_TZ(ArrivalTime, 'UTC', 'America/New_York'))
                    BETWEEN '15:00:00' AND '17:00:00'
        ", bus)
            .FirstOrDefaultAsync();

        return result.HasValue ? TimeOnly.FromTimeSpan(result.Value) : null;
    }
}