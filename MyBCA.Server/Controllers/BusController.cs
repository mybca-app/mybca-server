using Microsoft.AspNetCore.Mvc;
using MyBCA.Server.Dtos.Bus;
using MyBCA.Server.Services.Bus;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Mappings;
using System.Text;
using System.Globalization;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("AllowAll")]
public class BusController(IBusService busService, IBusArrivalService arrivalService) : ControllerBase
{
    [EndpointSummary("Retrieves a map of each bus to its position")]
    [HttpGet("List")]
    public async Task<ActionResult<BusApiResponse>> List()
    {
        var locations = await busService.GetPositionsMapAsync();

        return Ok(new BusApiResponse(locations.Count, locations, busService.Expiry));
    }

    [EndpointSummary("Retrieves a history of a bus's arrivals")]
    [HttpGet("History")]
    public async Task<ActionResult<IEnumerable<BusArrivalDto>>> History(string bus)
    {
        var arrivals = await arrivalService.GetArrivalsByBusAsync(bus);

        return Ok(arrivals.Select(a => a.ToDto()));
    }

    [EndpointSummary("Generates a CSV report of all bus arrival data")]
    [HttpGet("Reports/Generate")]
    public async Task<FileContentResult> GenerateReport()
    {
        var dtos = (await arrivalService.GetAllArrivalsAsync()).Select(a => a.ToDto());

        var sb = new StringBuilder();
        sb.AppendLine("bus_name,bus_position,arrival_time");

        foreach (var arrival in dtos)
        {
            var date = arrival.ArrivalTime.ToString("yyyy-MM-dd'T'HH:mm:sszzz", CultureInfo.InvariantCulture);
            sb.AppendLine($"{Escape(arrival.BusName ?? "")},{Escape(arrival.BusPosition ?? "")},{Escape(date)}");
        }

        return File(
            Encoding.UTF8.GetBytes(sb.ToString()),
            "text/csv",
            "mybca_bus_report.csv"
        );
    }

    private static string Escape(string value)
    {
        if (value.Contains('"') || value.Contains(',') || value.Contains('\n'))
            return $"\"{value.Replace("\"", "\"\"")}\"";
        return value;
    }
}