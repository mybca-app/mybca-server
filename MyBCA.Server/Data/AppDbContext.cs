using Microsoft.EntityFrameworkCore;
using MyBCA.Server.Models.Bus;

namespace MyBCA.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BusArrival> BusArrivals => Set<BusArrival>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}