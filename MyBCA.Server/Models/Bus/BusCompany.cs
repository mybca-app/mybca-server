using System.ComponentModel.DataAnnotations;

namespace MyBCA.Server.Models.Bus;

public class BusCompany
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public required string Name { get; set; }
}