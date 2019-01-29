using System;
using CleanArchitectureTemplate.Domain.Shared;

namespace CleanArchitectureTemplate.Domain.ToDos
{
    public class ToDoItem : BaseEntity
    {
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
