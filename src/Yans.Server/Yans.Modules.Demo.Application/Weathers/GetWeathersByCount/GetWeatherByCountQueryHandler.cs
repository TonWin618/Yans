using Microsoft.Extensions.Caching.Distributed;
using Yans.Base.Application.Queries;
using Yans.Base.Domain;
using Yans.Modules.Demo.Application.Weathers.DTOs;
using Yans.Modules.Demo.Domain.Weathers;

namespace Yans.Modules.Demo.Application.Weathers.GetWeathersByCount;

public sealed class GetWeatherByCountQueryHandler : IQueryHandler<GetWeatherByCountQuery, GetWeatherByCountResult>
{
    private readonly IDemoRepository _demoRepository;
    private readonly IDistributedCache _cache;

    public GetWeatherByCountQueryHandler(IDemoRepository demoRepository, IDistributedCache cache)
    {
        _demoRepository = demoRepository;
        _cache = cache;
    }

    public async Task<GetWeatherByCountResult> Handle(GetWeatherByCountQuery request, CancellationToken cancellationToken)
    {
        var weatherDtos = await _cache.GetAsync<WeatherDto[]>("weathers");

        if(weatherDtos == null)
        {
            var weathers = await _demoRepository.GetWeathersAsync(request.Count);

            weatherDtos = weathers
            .Select(w => new WeatherDto(w.Date, w.TemperatureC, w.Summary))
            .ToArray();

            await _cache.SetAsync("weathers", weatherDtos, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10) // 设置过期时间
            });
        }

        

        return GetWeatherByCountResult.CreateFromWeatherDtos(weatherDtos);
    }
}
