namespace Yans.Base.IntegrationEvents;

public abstract class IntegrationEvent
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    protected IntegrationEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }

    protected IntegrationEvent(Guid id, DateTime occurredOn)
    {
        Id = id;
        OccurredOn = occurredOn;
    }
}