
namespace Yans.Base.Domain;

public abstract class DomainEventBase : IDomainEvent
{
    public Guid Id { get;  init; }

    public DateTime OccurredOn { get; }
}
