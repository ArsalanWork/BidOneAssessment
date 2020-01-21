using System.Linq;
using System.Threading.Tasks;
using BidOneAssessment.Core;
using MediatR;

namespace BidOneAssessment.Infrastructure.Mediator
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, BidOneAssessmentContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<DomainEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            if (domainEvents.Any())
            {
                domainEntities.ToList().ForEach(entity => entity.Entity.DomainEvents.Clear());

                var tasks = domainEvents
                    .Select(async (domainEvent) =>
                    {
                        await mediator.Publish(domainEvent);
                    });

                await Task.WhenAll(tasks);

                // repeat until the event dispatching doesn't result in anymore events.
                await mediator.DispatchDomainEventsAsync(ctx);
            }
        }
    }
}
