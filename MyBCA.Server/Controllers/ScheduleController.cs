using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Services.Schedule;
using MyBCA.Server.Models.Schedule;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("AllowAll")]
public class ScheduleController(IScheduleService scheduleService) : ControllerBase
{
    [EndpointSummary("Retrieves details of the schedule for a day")]
    [HttpGet("Day/{date}")]
    public async Task<ActionResult<ScheduleDay?>> Day(DateOnly date)
    {
        var schedule = await scheduleService.GetScheduleDayAsync(date);

        return schedule is null ? Ok(new { }) : Ok(schedule);
    }
}