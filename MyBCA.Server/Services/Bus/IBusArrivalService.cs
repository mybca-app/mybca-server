using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public interface IBusArrivalService
{
    Task<BusArrival> CreateArrivalAsync(string bus, string location);
    Task<IEnumerable<BusArrival>> GetArrivalsByBusAsync(string bus);
    Task<IEnumerable<BusArrival>> GetArrivalsAsync(DateOnly? start, DateOnly? end);
}
