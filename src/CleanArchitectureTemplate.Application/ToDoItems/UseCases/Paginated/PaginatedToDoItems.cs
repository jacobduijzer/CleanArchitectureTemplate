using CleanArchitectureTemplate.Domain.ToDoItems;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItems
    {
        public readonly IEnumerable<ToDoItem> ToDoItems;
        public readonly bool HasPreviousPage;
        public readonly bool HasNextPage;
        public readonly int CurrentPageNumber;

        public PaginatedToDoItems(
            IEnumerable<ToDoItem> toDoItems,
            bool hasPreviousPage,
            bool hasNextPage,
            int currentPageNumber)
        {
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
            CurrentPageNumber = currentPageNumber;
            ToDoItems = toDoItems;
        }
    }
}
