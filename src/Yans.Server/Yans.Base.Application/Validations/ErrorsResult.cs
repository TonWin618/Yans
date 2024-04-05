namespace Yans.Base.Application.Validations;

public class ErrorsResult : ValidationResultBase
{
    public override Guid Guid { get; }

    public override bool Success { get; protected set; }

    public override string[] Errors { get; protected set; }

    public ErrorsResult(string[] errors)
    {
        Guid = Guid.NewGuid();
        Success = false;
        Errors = errors;
    }

    public static ErrorsResult CreateFromErrors(string[] errors)
    {
        return new ErrorsResult(errors);
    }
}
