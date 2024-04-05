using Yans.Base.Application;
using Yans.Base.IntegrationEvents;

namespace Yans.BuildingBlocks.EventBus.InMemory;

public class InMemoryEventBus : IEventBus
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public InMemoryEventBus()
    {
        _handlersDictionary = new Dictionary<string, List<IIntegrationEventHandler>>();
    }

    public static InMemoryEventBus Instance { get; } = new InMemoryEventBus();

    private readonly IDictionary<string, List<IIntegrationEventHandler>> _handlersDictionary;

    public async Task Publish<T>(T @event) where T : IntegrationEvent
    {
        var eventType = @event.GetType().FullName;

        if (eventType == null)
        {
            return;
        }

        List<IIntegrationEventHandler> integrationEventHandlers = _handlersDictionary[eventType];

        foreach (var integrationEventHandler in integrationEventHandlers)
        {
            if (integrationEventHandler is IIntegrationEventHandler<T> handler)
            {
                await handler.Handle(@event);
            }
        }
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
    {
        var eventType = typeof(T).FullName;
        if (eventType != null)
        {
            if (_handlersDictionary.ContainsKey(eventType))
            {
                var handlers = _handlersDictionary[eventType];
                handlers.Add(handler);
            }
            else
            {
                _handlersDictionary.Add(eventType, new List<IIntegrationEventHandler> { handler });
            }
        }
    }
}
