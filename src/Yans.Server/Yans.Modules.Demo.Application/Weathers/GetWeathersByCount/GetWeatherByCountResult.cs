using Yans.Base.Application.Validations;
using Yans.Modules.Demo.Application.Weathers.DTOs;

namespace Yans.Modules.Demo.Application.Weathers.GetWeathersByCount;

public sealed class GetWeatherByCountResult : ValidationResultBase
{
    public override Guid Guid { get; }

    public override bool Success { get; protected set; }

    public override string[] Errors { get; protected set; }

    public WeatherDto[] Weathers { get; private set; }

    public GetWeatherByCountResult() { }

    public GetWeatherByCountResult(bool success, string[] errors, WeatherDto[] WeatherDtos)
    {
        Guid = Guid.NewGuid();
        Success = success;
        Errors = errors;
        Weathers = WeatherDtos;
    }

    public static GetWeatherByCountResult CreateFromWeatherDtos(WeatherDto[] weatherDtos)
    {
        return new GetWeatherByCountResult(true, [], weatherDtos);
    }
}
