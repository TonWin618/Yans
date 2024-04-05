using Microsoft.EntityFrameworkCore;
using Yans.Modules.Demo.Domain.Weathers.Entities;

namespace Yans.Modules.Demo.Infrastructure;

public class DemoDbContext:DbContext
{
    public DbSet<Weather> Weathers { get; private set; }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weather>().HasKey(w => w.Id);
    }
}
