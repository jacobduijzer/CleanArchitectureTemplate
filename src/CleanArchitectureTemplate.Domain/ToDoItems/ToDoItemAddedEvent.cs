using CleanArchitectureTemplate.Domain.Shared;

namespace CleanArchitectureTemplate.Domain.ToDoItems
{
    public class ToDoItemAddedEvent
        : DomainEventBase
    {
        public ToDoItemAddedEvent(ToDoItem todoItem) =>
            ToDoItem = todoItem;

        public ToDoItem ToDoItem { get; }
    }
}
