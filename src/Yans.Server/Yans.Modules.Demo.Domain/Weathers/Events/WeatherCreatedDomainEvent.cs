using Yans.Base.Domain;

namespace Yans.Modules.Demo.Domain.Weathers.Events;

public class WeatherCreatedDomainEvent : DomainEventBase
{
    public DateOnly DateOnly {  get; }

    public WeatherCreatedDomainEvent(DateOnly dateOnly)
    {
        this.DateOnly = dateOnly;
    }
}
