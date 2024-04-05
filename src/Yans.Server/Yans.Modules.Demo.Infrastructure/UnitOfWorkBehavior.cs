using MediatR;
using Yans.Base.Infrastructure;

namespace Yans.Modules.Demo.Infrastructure;

public class UnitOfWorkBehavior<TRequest, TResult> : UnitOfWorkBehavior<TRequest, TResult, DemoDbContext>
    where TRequest : IRequest<TResult>
{
    public UnitOfWorkBehavior(DemoDbContext demoDbContext, IMediator mediator): base(demoDbContext, mediator)
    {

    }
}
