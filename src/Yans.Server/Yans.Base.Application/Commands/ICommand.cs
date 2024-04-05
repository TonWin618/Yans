using MediatR;

namespace Yans.Base.Application.Commands;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}
