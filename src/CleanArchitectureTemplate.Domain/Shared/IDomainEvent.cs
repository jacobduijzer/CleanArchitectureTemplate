using MediatR;
using System;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface IDomainEvent
        : INotification
    {
        DateTime OccurredOn { get; }
    }
}
