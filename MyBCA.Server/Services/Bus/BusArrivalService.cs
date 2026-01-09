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

    public async Task<IEnumerable<BusArrival>> GetAllArrivalsAsync()
    {
        List<BusArrival> arrivals = await db.BusArrivals
            .OrderByDescending(a => a.ArrivalTime)
            .ToListAsync();

        return arrivals;
    }
}