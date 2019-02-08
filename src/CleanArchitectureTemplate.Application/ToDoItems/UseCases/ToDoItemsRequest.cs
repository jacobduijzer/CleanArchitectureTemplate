using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder.Core;
using MediatR;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsRequest : IRequest<ToDoItemsResponse>
    {
        public readonly ISpecification<ToDoItem> Specification;

        public ToDoItemsRequest(ISpecification<ToDoItem> specification)
        {
            Guard.Against.Null(specification, "Specification");

            Specification = specification;
        }
    }
}
