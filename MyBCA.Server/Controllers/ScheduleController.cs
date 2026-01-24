using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Services.Schedule;
using MyBCA.Server.Dtos.Schedule;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/schedules")]
[EnableCors("AllowAll")]
public class ScheduleController(IScheduleService scheduleService) : ControllerBase
{
    [EndpointSummary("Retrieves details of the schedule for a day")]
    [HttpGet("{date}")]
    public async Task<ActionResult<ScheduleDayDto>> Day(DateOnly date)
    {
        var schedule = await scheduleService.GetScheduleDayAsync(date);

        return schedule is null ? Ok(new { }) : Ok(schedule);
    }
}