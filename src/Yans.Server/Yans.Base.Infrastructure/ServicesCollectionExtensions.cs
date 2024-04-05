using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Yans.Base.Application;

namespace Yans.Base.Infrastructure;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddIntegationEventHandlers(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        List<Type> eventHandlers = new List<Type>();
        foreach (var asm in assemblies)
        {
            //Modify to IIntegrationEventHandler<> limitation
            var handlerTypes = asm.GetTypes()
                .Where(t => t.IsAbstract == false && t.IsAssignableTo(typeof(IIntegrationEventHandler)));


            foreach (var handlerType in handlerTypes)
            {
                services.AddSingleton(typeof(IIntegrationEventHandler), handlerType);
            }
        }
        return services;
    }
}
