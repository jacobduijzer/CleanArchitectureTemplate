using System;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public class DomainEventBase
        : IDomainEvent
    {
        public DomainEventBase() =>
            OccurredOn = DateTime.Now;

        public DateTime OccurredOn { get; }
    }
}
