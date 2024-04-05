using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Yans.Base.Application;

namespace Yans.BuildingBlocks.EventBus.InMemory;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder MapEventHandlers(this IApplicationBuilder app)
    {
        var eventBus = app.ApplicationServices.GetService<IEventBus>();

        if (eventBus == null)
        {
            throw new InvalidOperationException("The event bus was not found.");
        }

        var handlers = app.ApplicationServices.GetServices<IIntegrationEventHandler>();

        foreach (var handler in handlers)
        {
            var eventType = handler.GetType()
                .GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IIntegrationEventHandler<>))
                ?.GetGenericArguments().FirstOrDefault();

            if (eventType == null)
            {
                continue;
            }

            var subscribeMethod = eventBus.GetType()?.GetMethod(nameof(eventBus.Subscribe))?.MakeGenericMethod([eventType]);
            subscribeMethod?.Invoke(eventBus, [handler]);
        }
        return app;
    }
}
