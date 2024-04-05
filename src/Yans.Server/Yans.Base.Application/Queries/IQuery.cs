using MediatR;

namespace Yans.Base.Application.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}
