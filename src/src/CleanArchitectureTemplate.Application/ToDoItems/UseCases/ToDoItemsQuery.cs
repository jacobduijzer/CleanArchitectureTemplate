using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System.Collections.Generic;
using LinqBuilder;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsQuery
        : IRequest<IEnumerable<ToDoItem>>
    {
        public readonly QuerySpecification<ToDoItem> Specification;

        public ToDoItemsQuery(QuerySpecification<ToDoItem> specification)
        {
            Guard.Against.Null(specification, "Specification");

            Specification = specification;
        }
    }
}
