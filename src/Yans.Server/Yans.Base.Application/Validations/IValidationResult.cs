namespace Yans.Base.Application.Validations;

public interface IValidationResult
{
    Guid Guid { get; }

    public bool Success { get; }

    public string[] Errors { get; }

    public void AddErrors(string[] errors);
}
