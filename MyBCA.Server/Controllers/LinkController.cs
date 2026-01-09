using Microsoft.AspNetCore.Mvc;
using MyBCA.Server.Dtos.Links;
using MyBCA.Server.Services.Links;
using Microsoft.AspNetCore.Cors;
using MyBCA.Server.Mappings;

namespace MyBCA.Server.Controllers;

[ApiController]
[Route("api/Links")]
[EnableCors("AllowAll")]
public class LinkController(ILinkService linkService) : ControllerBase
{
    [EndpointSummary("Retrieves a list of quick links to key BCA services")]
    [HttpGet]
    public ActionResult<LinkApiResponse> GetLinks()
    {
        var links = linkService.GetLinks();
        return Ok(new LinkApiResponse(links.Count(), links.Select(l => l.ToDto())));
    }
}