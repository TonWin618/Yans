using FluentValidation;
using Yans.Base.Application.Commands;
using Yans.Base.Application.Validations;

namespace Yans.Modules.Demo.Application.Weathers.CreateWeather;

public sealed class CreateWeatherCommand : CommandBase<CreateWeatherResult>, IValidation<CreateWeatherCommand>
{
    public DateOnly Date { get; }

    public int TemperatureC { get; }

    public string? Summary { get; }

    public CreateWeatherCommand(DateOnly date, int temperatureC, string summary) 
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public InlineValidator<CreateWeatherCommand> UseRules(InlineValidator<CreateWeatherCommand> validator)
    {
        string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        validator.RuleFor(request => request.Date)
            .Must(date => date > DateOnly.FromDateTime(DateTime.Today))
            .WithMessage($"{nameof(Date)}:date_cannot_be_in_the_past");

        validator.RuleFor(request => request.TemperatureC)
            .LessThan(60)
            .WithMessage($"{nameof(TemperatureC)}:must_less_than_{60}")
            .GreaterThan(-100)
            .WithMessage($"{nameof(TemperatureC)}:must_greater_than_{-100}");

        validator.RuleFor(requst => requst.Summary)
            .Must(s => Summaries.Contains(s))
            .WithMessage($"{nameof(Summary)}:not_in_list");

        return validator;
    }
}
