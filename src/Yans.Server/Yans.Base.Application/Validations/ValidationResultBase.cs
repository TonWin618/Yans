namespace Yans.Base.Application.Validations;

public abstract class ValidationResultBase : IValidationResult
{
    public abstract Guid Guid { get; }

    public abstract bool Success { get; protected set; }

    public abstract string[] Errors { get; protected set; }

    public void AddErrors(string[] errors)
    {
        Success = false;

        if (Errors == null)
        {
            Errors = errors;
        }
        else
        {
            Errors = errors.Concat(Errors).ToArray();
        }
    }
}
