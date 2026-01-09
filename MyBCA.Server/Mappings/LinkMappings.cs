using MyBCA.Server.Dtos.Links;
using MyBCA.Server.Models.Links;

namespace MyBCA.Server.Mappings;

public static class LinkMappings
{
    public static LinkDto ToDto(this Link link)
    {
        return new LinkDto(
            Name: link.Name,
            Target: link.Target
        );
    }
}