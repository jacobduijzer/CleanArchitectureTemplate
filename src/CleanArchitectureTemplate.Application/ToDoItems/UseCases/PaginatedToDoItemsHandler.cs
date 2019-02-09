using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder.OrderBy;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsHandler 
        : BasePagedHandler<ToDoItem>, IRequestHandler<PaginatedToDoItemsRequest, PaginatedToDoItemsResponse>
    {
        private readonly IRepository<ToDoItem> repository;

        public PaginatedToDoItemsHandler(IRepository<ToDoItem> repository) 
            : base(repository) =>
                this.repository = repository;

        public async Task<PaginatedToDoItemsResponse> Handle(
            PaginatedToDoItemsRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await repository.GetItemsAsync(
                    request.Specification.Paginate(request.PageNumber, request.PageSize)
                ).ConfigureAwait(false);

                var hasPreviousRecords = await base.HasPreviousPage(
                        request.Specification,
                        request.PageNumber,
                        request.PageSize).ConfigureAwait(false);

                var hasNextRecords = await base.HasNextPage(
                    request.Specification,
                    request.PageNumber,
                    request.PageSize).ConfigureAwait(false);

                return new PaginatedToDoItemsResponse(
                    response,
                    hasPreviousRecords,
                    hasNextRecords,
                    request.PageNumber);
            }
            catch (Exception ex)
            {
                // TODO: Error handling
                return new PaginatedToDoItemsResponse(false, ex.Message);
            }
        }
    }
}
