using Microsoft.AspNetCore.Mvc;
using MyBCA.Server.Dtos.Bus;
using MyBCA.Server.Services.Bus;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Mappings;
using System.Text;
using System.Globalization;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/bus")]
[Route("api/buses")]
[EnableCors("AllowAll")]
public class BusController(IBusService busService, IBusInfoService busInfoService) : ControllerBase
{
    [EndpointSummary("Retrieves a map of each bus to its position")]
    [HttpGet("list")]
    [HttpGet]
    public async Task<ActionResult<BusApiResponse>> List()
    {
        var locations = await busService.GetPositionsMapAsync();

        return Ok(new BusApiResponse(locations.Count, locations, busService.Expiry));
    }

    [EndpointSummary("Retrieves information about a bus")]
    [HttpGet("info")]
    public async Task<ActionResult<BusInfoDto?>> Info(string bus)
    {
        var info = await busInfoService.GetInfoByBusAsync(bus);

        if (info is null)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                type: $"/errors/BusInfoNotFound",
                title: "Resource Not Found",
                detail: "Bus info for the given name not found.",
                instance: HttpContext.Request.Path
            );
        }

        return Ok(info.ToDto());
    }

    [EndpointSummary("Retrieves a history of a bus's arrivals")]
    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<BusArrivalDto>>> History(string bus)
    {
        var arrivals = await busInfoService.GetArrivalsByBusAsync(bus);

        return Ok(arrivals.Select(a => a.ToDto()));
    }

    [EndpointSummary("Generates a CSV report of all bus arrival data")]
    [HttpGet("reports/generate")]
    public async Task<FileContentResult> GenerateReport(DateOnly? start = null, DateOnly? end = null)
    {
        var dtos = (await busInfoService.GetArrivalsAsync(start, end)).Select(a => a.ToDto());

        var sb = new StringBuilder();
        sb.AppendLine("bus_name,bus_position,detected_date,detected_time");

        foreach (var arrival in dtos)
        {
            var local = arrival.ArrivalTime.ToLocalTime();
            var date = local.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var time = local.ToString("h:mm:ss tt", CultureInfo.InvariantCulture);
            sb.Append($"{Escape(arrival.BusName ?? "")},");
            sb.Append($"{Escape(arrival.BusPosition ?? "")},");
            sb.Append($"{Escape(date)},");
            sb.AppendLine($"{Escape(time)}");
        }

        return File(
            Encoding.UTF8.GetBytes(sb.ToString()),
            "text/csv",
            $"mybca-report-bus-{DateTime.Now:yyyy-MM-dd}.csv"
        );
    }

    private static string Escape(string value)
    {
        if (value.Contains('"') || value.Contains(',') || value.Contains('\n'))
            return $"\"{value.Replace("\"", "\"\"")}\"";
        return value;
    }
}