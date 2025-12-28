using System.ComponentModel.DataAnnotations;

namespace MyBCA.Server.Models.Bus;

public class BusArrival
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string? BusName { get; set; } = null;

    [Required, MaxLength(50)]
    public string? BusPosition { get; set; } = null;

    public DateTime ArrivalTime { get; set; } = DateTime.UtcNow;
}