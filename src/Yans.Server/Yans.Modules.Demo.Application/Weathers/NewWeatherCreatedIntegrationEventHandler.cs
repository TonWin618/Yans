using Microsoft.Extensions.Logging;
using Yans.Base.Application;
using Yans.Modules.Demo.IntegrationEvents;

namespace Yans.Modules.Demo.Application.Weathers;

public class NewWeatherCreatedIntegrationEventHandler : IIntegrationEventHandler<NewWeatherCreatedIntegrationEvent>
{
    private readonly ILogger _logger;

    public NewWeatherCreatedIntegrationEventHandler(ILogger<NewWeatherCreatedIntegrationEvent> logger)
    {
        _logger = logger;
    }

    public async Task Handle(NewWeatherCreatedIntegrationEvent @event)
    {
        _logger.LogInformation($"The NewWeatherCreatedIntegrationEvent has been processed.");
    }
}
