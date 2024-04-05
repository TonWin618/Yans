using Microsoft.Extensions.DependencyInjection;

namespace Yans.Base.Infrastructure;

public interface IModuleInitializer
{
    public void AddModuleServices(IServiceCollection services);
}
