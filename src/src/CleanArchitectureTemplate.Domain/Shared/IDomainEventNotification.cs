using MediatR;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IDomainEventNotification<out TEventType>
        : INotification
    {
        TEventType DomainEvent { get; }
    }
}
