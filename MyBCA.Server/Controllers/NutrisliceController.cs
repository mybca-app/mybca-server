using Microsoft.AspNetCore.Mvc;
using MyBCA.Server.Models.Nutrislice;
using MyBCA.Server.Dtos.Nutrislice;
using MyBCA.Server.Services.Nutrislice;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Mappings;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/Lunch/[action]")]
[EnableCors("AllowAll")]
public class NutrisliceController(INutrisliceService menuService) : ControllerBase
{
    [EndpointSummary("Retrieves the lunch menu for the week")]
    [HttpGet]
    public async Task<ActionResult<NutrisliceApiResponse<MenuWeekDto>>> Week()
    {
        var week = await menuService.GetMenuWeekAsync();
        return Ok(new NutrisliceApiResponse<MenuWeekDto>(week.ToDto(), menuService.Expiry));
    }

    [EndpointSummary("Retrieves the lunch menu for the day")]
    [HttpGet]
    public async Task<ActionResult<NutrisliceApiResponse<MenuDayDto>>> Day()
    {
        var day = await menuService.GetMenuDayAsync();
        if (day is null)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                type: $"/errors/MenuDayNotFound",
                title: "Resource Not Found",
                detail: "Menu data for this week not found.",
                instance: HttpContext.Request.Path
            );
        }

        return Ok(new NutrisliceApiResponse<MenuDayDto>(day.ToDto(), menuService.Expiry));
    }
}