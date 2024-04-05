using MediatR;
using Microsoft.EntityFrameworkCore;
using Yans.Base.Domain;

namespace Yans.Base.Infrastructure;

public class UnitOfWorkBehavior<TRequest, TResult, TDbContext> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly IMediator _mediator;

    public UnitOfWorkBehavior(TDbContext serviceProvider,IMediator mediator)
    {
        _dbContext = serviceProvider;
        _mediator = mediator;
    }

    public virtual async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var response = await next();

        var domainEntities = _dbContext.ChangeTracker
            .Entries<IDomainEvents>()
            .Where(x => x.Entity.DomainEvents?.Count > 0);

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents??[])
            .ToList();

        foreach (var domainEvent in domainEvents )
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        await _dbContext.SaveChangesAsync();

        return response;
    }
}
