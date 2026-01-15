using System.ComponentModel.DataAnnotations;

namespace MyBCA.Server.Models.Bus;

public class BusInfo
{
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public required string Name { get; set; }
    public int? CompanyId { get; set; }
    public BusCompany? Company { get; set; }
}