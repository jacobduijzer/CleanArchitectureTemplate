using CleanArchitectureTemplate.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public interface IDomainEventsDispatcher
    {
        Task<List<IDomainEventNotification<IDomainEvent>>> DispatchEventsAsync(AppDbContext context);
    }
}
