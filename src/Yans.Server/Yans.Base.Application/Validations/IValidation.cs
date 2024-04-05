using FluentValidation;

namespace Yans.Base.Application.Validations;

public interface IValidation<TRequest>
{
    InlineValidator<TRequest> UseRules(InlineValidator<TRequest> validator);
}
