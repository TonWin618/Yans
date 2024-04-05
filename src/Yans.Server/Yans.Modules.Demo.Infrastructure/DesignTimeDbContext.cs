using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Yans.Base.Infrastructure;

namespace Yans.Modules.Demo.Infrastructure;

internal class IDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
{
    public DemoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DemoDbContext>();
        optionsBuilder.UseSqlite(DbConnectionStringProvider.GetConnectionString<DemoDbContext>());
        return new DemoDbContext(optionsBuilder.Options);
    }
}
