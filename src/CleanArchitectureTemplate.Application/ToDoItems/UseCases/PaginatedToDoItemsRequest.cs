using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsRequest : IRequest<PaginatedToDoItemsResponse>
    {
        public readonly ICacheableDataSpecification<ToDoItem> Specification;

        public readonly int PageNumber;

        public readonly int PageSize;

        public PaginatedToDoItemsRequest(
            ICacheableDataSpecification<ToDoItem> specification, 
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