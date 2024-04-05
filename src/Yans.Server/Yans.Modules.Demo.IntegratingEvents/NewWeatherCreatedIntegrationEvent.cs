using Yans.Base.IntegrationEvents;

namespace Yans.Modules.Demo.IntegrationEvents
{
    public class NewWeatherCreatedIntegrationEvent : IntegrationEvent
    {
        DateOnly DateOnly { get; }

        public NewWeatherCreatedIntegrationEvent(DateOnly dateOnly) : base()
        {
            DateOnly = dateOnly;
        }

        public NewWeatherCreatedIntegrationEvent(Guid id, DateTime occurredOn, DateOnly dateOnly) : base(id, occurredOn)
        {
            DateOnly = dateOnly;
        }
    }
}
