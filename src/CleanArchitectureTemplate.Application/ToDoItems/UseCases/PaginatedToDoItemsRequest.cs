using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder.Core;
using MediatR;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsRequest : IRequest<PaginatedToDoItemsResponse>
    {
        public readonly ISpecification<ToDoItem> Specification;

        public readonly int PageNumber;

        public readonly int PageSize;

        public PaginatedToDoItemsRequest(
            ISpecification<ToDoItem> specification, 
            int pageNumber, 
            int pageSize)
        {
            if (pageNumber == 0)
                pageNumber = 1;

            Specification = specification;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}