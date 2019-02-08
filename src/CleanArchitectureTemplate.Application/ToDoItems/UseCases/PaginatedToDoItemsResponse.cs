using CleanArchitectureTemplate.Domain.ToDoItems;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsResponse : ToDoItemsResponse
    {
        public readonly int PageNumber;

        public PaginatedToDoItemsResponse(IEnumerable<ToDoItem> books, int pageNumber)
            : base(books) =>
                PageNumber = pageNumber;

        public PaginatedToDoItemsResponse(bool isSucess)
            : base(false)
        { }

        public PaginatedToDoItemsResponse(bool isSucess, string message)
            : base(false, message)
        { }
    }
}