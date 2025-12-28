using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public interface IBusLogService
{
    Task<BusArrival> CreateArrivalLog(string Bus, string Location);
}
