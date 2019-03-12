using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsQuery
        : IRequest<IEnumerable<ToDoItem>>
    {
        public readonly ICacheableDataSpecification<ToDoItem> Specification;

        public ToDoItemsQuery(ICacheableDataSpecification<ToDoItem> specification)
        {
            Guard.Against.Null(specification, "Specification");

            Specification = specification;
        }
    }
}
