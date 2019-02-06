using System;
using System.Collections.Generic;
using CleanArchitectureTemplate.Domain.ToDoItems;

namespace CleanArchitectureTemplate.FakeData.ToDoItems
{
    public static class ToDoItemData
    {
        public static List<ToDoItem> ToDoItems => new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Description = "Do the dishes", DueDate = DateTime.Now.AddDays(-3), IsDone = true },
            new ToDoItem { Id = 2, Description = "Clean the aquarium pump", DueDate = DateTime.Now.AddDays(1), IsDone = true },
            new ToDoItem { Id = 3, Description = "Vacuum the living room", DueDate = DateTime.Now.AddDays(3), IsDone = false }
        };
    }
}
