using Microsoft.AspNetCore.Mvc;
using MyBCA.Shared.Models.Bus.Responses;
using MyBCA.Server.Services.Bus;
using Microsoft.AspNetCore.Cors;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[EnableCors("AllowAll")]
public class BusController(IBusService busService) : ControllerBase
{
    [EndpointSummary("Retrieves a map of each bus to its position")]
    [HttpGet]
    public async Task<ActionResult<BusApiResponse>> List()
    {
        var locations = await busService.GetPositionsMapAsync();

        return Ok(new BusApiResponse(locations.Count, locations, busService.Expiry));
    }
}