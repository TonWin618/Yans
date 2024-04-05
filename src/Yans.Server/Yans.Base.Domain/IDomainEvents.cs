namespace Yans.Base.Domain;

public interface IDomainEvents
{
    IReadOnlyCollection<IDomainEvent>? DomainEvents { get; }

    void ClearDomainEvents();

    protected void AddDomainEvent(IDomainEvent domainEvent);
}
