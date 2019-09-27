using CleanArchitectureTemplate.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class DomainEventsDispatcher
        : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public DomainEventsDispatcher(
            IMediator mediator,
            IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<IDomainEventNotification<IDomainEvent>>> DispatchEventsAsync(AppDbContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
            foreach (var domainEvent in domainEvents)
            {
                Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWithGenericType = domainEvenNotificationType.MakeGenericType(domainEvent.GetType());

                var domainNotification = _serviceProvider.GetService(domainEvenNotificationType);

                if (domainNotification != null)
                {
                    domainEventNotifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                }
            }

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);

            return domainEventNotifications;
        }
    }
}
