using FluentValidation;
using Yans.Base.Application.Queries;
using Yans.Base.Application.Validations;

namespace Yans.Modules.Demo.Application.Weathers.GetWeathersByCount;

public sealed class GetWeatherByCountQuery : QueryBase<GetWeatherByCountResult>, IValidation<GetWeatherByCountQuery>
{
    public int Count { get; }

    public GetWeatherByCountQuery(int count)
    {
        Count = count;
    }

    public InlineValidator<GetWeatherByCountQuery> UseRules(InlineValidator<GetWeatherByCountQuery> validator)
    {
        validator.RuleFor(request => request.Count)
            .GreaterThan(0)
            .WithMessage($"{nameof(Count)}:must_greater_than_0")
            .LessThan(30)
            .WithMessage($"{nameof(Count)}:must_less_than_30");

        return validator;
    }
}
