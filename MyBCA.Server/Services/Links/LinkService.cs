using Microsoft.Extensions.Options;
using MyBCA.Server.Dtos.Links;
using MyBCA.Server.Mappings;

namespace MyBCA.Server.Services.Links;

public class LinkService(IOptions<LinkOptions> options) : ILinkService
{
    public IEnumerable<LinkDto> GetLinks() => options.Value.Links.Select(l => l.ToDto());
}