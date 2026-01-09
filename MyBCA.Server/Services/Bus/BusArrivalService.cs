using Microsoft.EntityFrameworkCore;
using MyBCA.Server.Data;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public class BusArrivalService(AppDbContext db) : IBusArrivalService
{
    public async Task<BusArrival> CreateArrivalAsync(string bus, string location)
    {
        var log = new BusArrival
        {
            BusName = bus,
            BusPosition = location
        };

        db.BusArrivals.Add(log);
        await db.SaveChangesAsync();

        return log;
    }

    public async Task<IEnumerable<BusArrival>> GetArrivalsByBusAsync(string bus)
    {
        List<BusArrival> arrivals = await db.BusArrivals
            .Where(a => a.BusName == bus)
            .OrderByDescending(a => a.ArrivalTime)
            .ToListAsync();

        return arrivals;
    }

    public async Task<IEnumerable<BusArrival>> GetArrivalsAsync(
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
            .ToListAsync();
    }
}