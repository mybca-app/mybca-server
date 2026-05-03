namespace MyBCA.Server.Dtos.Bus;

public record BusInfoDto(string Name, BusCompanyDto? Company, TimeOnly? AverageArrivalTime);