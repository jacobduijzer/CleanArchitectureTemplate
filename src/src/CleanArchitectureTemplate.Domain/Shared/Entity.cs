using System;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents() => _domainEvents?.Clear();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }
    }
}
