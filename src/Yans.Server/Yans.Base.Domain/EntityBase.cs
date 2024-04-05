using System.ComponentModel.DataAnnotations.Schema;

namespace Yans.Base.Domain;

public abstract class EntityBase: IDomainEvents, IEntity
{
    public Guid Id { get; protected set; }

    [NotMapped]
    private List<IDomainEvent>? domainEvents;

    [NotMapped]
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => domainEvents?.AsReadOnly();

    public void ClearDomainEvents()
    {
        domainEvents?.Clear();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents ??= [];
        domainEvents.Add(domainEvent);
    }
}
