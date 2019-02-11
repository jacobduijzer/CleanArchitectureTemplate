using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsRequest : IRequest<ToDoItemsResponse>
    {
        public readonly ICacheableDataSpecification<ToDoItem> Specification;

        public ToDoItemsRequest(ICacheableDataSpecification<ToDoItem> specification)
        {
            Guard.Against.Null(specification, "Specification");

            Specification = specification;
        }
    }
}
