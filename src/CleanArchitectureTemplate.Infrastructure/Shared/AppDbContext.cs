using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class AppDbContext
        : DbContext, IUnitOfWork
    {
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        private readonly IMediator _mediator;

        public AppDbContext(
           DbContextOptions<AppDbContext> options,
           IDomainEventsDispatcher domainEventsDispatcher,
           IMediator mediator)
           : base(options)
        {
            _domainEventsDispatcher = domainEventsDispatcher;
            _mediator = mediator;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            var notifications = await _domainEventsDispatcher.DispatchEventsAsync(this);
            var saveResult = await base.SaveChangesAsync(cancellationToken);

            var tasks = notifications
                .Select(async (notification) =>
                {
                    await _mediator.Publish(notification, cancellationToken);
                });

            await Task.WhenAll(tasks);

            return saveResult;
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        //}
    }
}
