using Yans.Base.Application.Validations;

namespace Yans.Modules.Demo.Application.Weathers.CreateWeather;

public sealed class CreateWeatherResult : ValidationResultBase
{
    public override Guid Guid { get; }

    public override bool Success { get; protected set; }

    public override string[] Errors { get; protected set; }

    public CreateWeatherResult() { }

    public CreateWeatherResult(bool success, string[] errors)
    {
        Guid = Guid.NewGuid();
        Success = success;
        Errors = errors;
    }

    public static CreateWeatherResult CreateFromSuccess()
    {
        return new CreateWeatherResult(true, []);
    }
}
