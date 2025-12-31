using MyBCA.Server.Data;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public class BusLogService(AppDbContext db) : IBusLogService
{
    public async Task<BusArrival> CreateArrivalLog(string Bus, string Location)
    {
        var log = new BusArrival
        {
            BusName = Bus,
            BusPosition = Location
        };

        db.BusArrivals.Add(log);
        await db.SaveChangesAsync();

        return log;
    }
}