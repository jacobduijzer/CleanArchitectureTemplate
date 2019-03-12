using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsQuery : IRequest<PaginatedToDoItems>
    {
        public readonly ICacheableDataSpecification<ToDoItem> Specification;

        public readonly int PageNumber;

        public readonly int PageSize;

        public PaginatedToDoItemsQuery(
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
