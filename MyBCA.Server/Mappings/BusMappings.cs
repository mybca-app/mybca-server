using MyBCA.Server.Dtos.Bus;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Mappings;

public static class BusMappings
{
    public static BusArrivalDto ToDto(this BusArrival arrival)
    {
        return new BusArrivalDto(
            BusName: arrival.BusName,
            BusPosition: arrival.BusPosition,
            ArrivalTime: arrival.ArrivalTime
        );
    }

    public static BusCompanyDto ToDto(this BusCompany company)
    {
        return new BusCompanyDto(
            Name: company.Name
        );
    }

    public static BusInfoDto ToDto(this BusInfo info)
    {
        return new BusInfoDto(
            Name: info.Name,
            Company: info.Company?.ToDto()
        );
    }
}