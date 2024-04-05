using FluentValidation;
using MediatR;

namespace Yans.Base.Application.Validations;

public class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IValidation<TRequest>
    where TResult : IValidationResult, new()
{
    public ValidationBehavior()
    {

    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var validator = new InlineValidator<TRequest>();
        var validationResult = request.UseRules(validator).Validate(request);

        if (!validationResult.IsValid)
        {
            var invalidResponse = new TResult();

            invalidResponse.AddErrors(
                validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToArray());

            return invalidResponse;
        }

        var response = await next();
        return response;
    }
}
