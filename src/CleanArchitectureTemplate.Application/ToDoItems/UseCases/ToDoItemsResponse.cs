using System.Collections.Generic;
using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsResponse : BaseResponse
    {
        public readonly IEnumerable<ToDoItem> ToDoItems;

        public ToDoItemsResponse(IEnumerable<ToDoItem> todoItems)
            : base(isSuccessful: true) =>
                ToDoItems = todoItems;

        public ToDoItemsResponse(bool isSuccessful)
            : base(isSuccessful)
        { }
    }
}
