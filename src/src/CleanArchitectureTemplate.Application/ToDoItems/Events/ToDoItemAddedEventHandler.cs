using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.Events
{
    public class ToDoItemAddedEventHandler
        : INotificationHandler<ToDoItemAddedEvent>
    {
        public async Task Handle(ToDoItemAddedEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
        }
    }
}
