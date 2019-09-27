using MediatR;
using System;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class CreateToDoItemRequest
        : IRequest<ToDoItemDto>
    {
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
