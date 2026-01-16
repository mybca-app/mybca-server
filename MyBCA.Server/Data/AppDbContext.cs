using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBCA.Server.Models.Bus;
using MyBCA.Server.Models.Schedule;

namespace MyBCA.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BusArrival> BusArrivals => Set<BusArrival>();
    public DbSet<BusInfo> BusInfos => Set<BusInfo>();
    public DbSet<BusCompany> BusCompanies => Set<BusCompany>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<ScheduleDay> ScheduleDays => Set<ScheduleDay>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var jsonOptions = new JsonSerializerOptions();

        modelBuilder.Entity<Schedule>()
            .Property(s => s.Items)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonOptions),
                v => JsonSerializer.Deserialize<List<ScheduleItem>>(v, jsonOptions) ?? new List<ScheduleItem>()
            );

        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)
        );

        modelBuilder.Entity<ScheduleDay>()
            .Property(s => s.Day)
            .HasConversion(dateOnlyConverter);
    }
}