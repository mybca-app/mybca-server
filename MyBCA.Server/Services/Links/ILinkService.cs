using MyBCA.Server.Dtos.Links;
using MyBCA.Server.Models.Links;

namespace MyBCA.Server.Services.Links;

public interface ILinkService
{
    IEnumerable<LinkDto> GetLinks();
}