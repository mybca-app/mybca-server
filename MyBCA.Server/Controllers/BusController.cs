using Microsoft.AspNetCore.Mvc;
using MyBCA.Server.Models.Bus.Responses;
using MyBCA.Server.Services.Bus;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Models.Bus;

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
    [HttpGet("{bus}/History")]
    public async Task<ActionResult<IEnumerable<BusArrival>>> History(string bus)
    {
        var arrivals = await arrivalService.GetArrivalsByBusAsync(bus);

        return Ok(arrivals);
    }
}