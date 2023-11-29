using Microsoft.EntityFrameworkCore;

namespace Bennetr.Lego.Api.Models;

public class LegoContext : DbContext
{
    public LegoContext(DbContextOptions<LegoContext> options) : base(options)
    {
    }

    public DbSet<LegoSet> LegoSets { get; set; } = null!;

    public DbSet<LegoPart> LegoParts { get; set; } = null!;

    public DbSet<Group> Groups { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
}

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio