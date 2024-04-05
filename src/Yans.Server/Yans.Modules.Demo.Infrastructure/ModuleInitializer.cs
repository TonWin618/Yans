using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yans.Base.Application;
using Yans.Base.Application.Validations;
using Yans.Base.Infrastructure;
using Yans.BuildingBlocks.EventBus.InMemory;
using Yans.Modules.Demo.Application;
using Yans.Modules.Demo.Domain.Weathers;

namespace Yans.Modules.Demo.Infrastructure;

public class ModuleInitializer : IModuleInitializer
{
    public void AddModuleServices(IServiceCollection services)
    {
        //Database
        services.AddScoped<IDemoRepository, DemoRepository>();
        var dbcs = DbConnectionStringProvider.GetConnectionString<DemoDbContext>();
        services.AddDbContext<DemoDbContext>(opt =>
        {
            opt.UseSqlite(dbcs);
        });

        //MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationAssemblyInfo).Assembly);
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));


        //EventBus
        services.AddSingleton<IEventBus, InMemoryEventBus>();
        services.AddIntegationEventHandlers([typeof(ApplicationAssemblyInfo).Assembly]);

        //Cache
        services.AddDistributedMemoryCache(opt =>
        {

        });
    }
}
