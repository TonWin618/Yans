using Yans.Base.Application;
using Yans.Base.Application.Commands;
using Yans.Modules.Demo.Domain.Weathers;
using Yans.Modules.Demo.Domain.Weathers.Entities;
using Yans.Modules.Demo.IntegrationEvents;

namespace Yans.Modules.Demo.Application.Weathers.CreateWeather;

public sealed class CreateWeatherCommandHandler : ICommandHandler<CreateWeatherCommand, CreateWeatherResult>
{
    private readonly IDemoRepository _demoRepository;
    private readonly IEventBus _eventBus;

    public CreateWeatherCommandHandler(IDemoRepository demoRepository,IEventBus eventBus)
    {
        _demoRepository = demoRepository;
        _eventBus = eventBus;

    }

    public async Task<CreateWeatherResult> Handle(CreateWeatherCommand request, CancellationToken cancellationToken)
    {
        var weather = new Weather(request.Date,request.TemperatureC, request.Summary);
        await _demoRepository.CreateWeatherAsync(weather);
        await _eventBus.Publish(new NewWeatherCreatedIntegrationEvent(weather.Date));
        return CreateWeatherResult.CreateFromSuccess();
    }
}
