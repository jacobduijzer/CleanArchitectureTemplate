using System.Collections.Generic;
using CleanArchitectureTemplate.Domain.ToDoItems;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsResponse
    {
        public readonly IEnumerable<ToDoItem> ToDoItems;

        public ToDoItemsResponse(IEnumerable<ToDoItem> todoItems) =>
            ToDoItems = todoItems;    
    }
}
