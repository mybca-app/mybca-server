using MyBCA.Server.Dtos.Bus;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Services.Bus;

public interface IBusInfoService
{
    Task<BusArrivalDto> CreateArrivalAsync(string bus, string location);
    Task<IEnumerable<BusArrivalDto>> GetArrivalsByBusAsync(string bus);
    Task<IEnumerable<BusArrivalDto>> GetArrivalsAsync(DateOnly? start, DateOnly? end);
    Task<BusInfoDto?> GetInfoByBusAsync(string bus);
}
