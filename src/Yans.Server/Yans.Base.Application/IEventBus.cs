using Yans.Base.IntegrationEvents;

namespace Yans.Base.Application;

public interface IEventBus : IDisposable
{
    Task Publish<T>(T @event)
        where T : IntegrationEvent;

    void Subscribe<T>(IIntegrationEventHandler<T> handler)
        where T : IntegrationEvent;
}
