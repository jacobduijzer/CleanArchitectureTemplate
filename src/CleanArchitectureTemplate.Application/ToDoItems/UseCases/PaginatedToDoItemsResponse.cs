using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsResponse : BasePagedResponse
    {
        public readonly IEnumerable<ToDoItem> ToDoItems;

        public PaginatedToDoItemsResponse(
            IEnumerable<ToDoItem> toDoItems,
            bool hasPreviousPage,
            bool hasNextPage,
            int currentPageNumber)
            : base(hasPreviousPage, hasNextPage, currentPageNumber) =>
                ToDoItems = toDoItems;

        public PaginatedToDoItemsResponse(bool isSucess)
            : base(false)
        { }

        public PaginatedToDoItemsResponse(bool isSucess, string message)
            : base(false, message)
        { }
    }
}