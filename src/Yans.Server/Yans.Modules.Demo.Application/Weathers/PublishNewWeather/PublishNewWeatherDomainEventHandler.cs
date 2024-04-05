using MediatR;
using Microsoft.Extensions.Logging;
using Yans.Modules.Demo.Domain.Weathers.Events;

namespace Yans.Modules.Demo.Application.Weathers.PublishNewWeather;

public class PublishNewWeatherDomainEventHandler : INotificationHandler<WeatherCreatedDomainEvent>
{
    private readonly ILogger _logger;

    public PublishNewWeatherDomainEventHandler(ILogger<PublishNewWeatherDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(WeatherCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"The WeatherCreatedDomainEvent has been processed.");
    }
}
