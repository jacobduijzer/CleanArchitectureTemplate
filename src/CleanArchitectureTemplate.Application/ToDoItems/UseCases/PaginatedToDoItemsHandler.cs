using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsHandler 
        : BasePagedHandler<ToDoItem>, IRequestHandler<PaginatedToDoItemsRequest, PaginatedToDoItemsResponse>
    {
        public PaginatedToDoItemsHandler(IReadOnlyRepository<ToDoItem> repository) 
            : base(repository)
        { }

        public async Task<PaginatedToDoItemsResponse> Handle(
            PaginatedToDoItemsRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var data = await base.GetItemsAsync(
                    request.Specification,
                    request.PageNumber,
                    request.PageSize).ConfigureAwait(false);

                var hasPreviousRecords = await base.HasPreviousPage(
                        request.Specification,
                        request.PageNumber,
                        request.PageSize).ConfigureAwait(false);

                var hasNextRecords = await base.HasNextPage(
                    request.Specification,
                    request.PageNumber,
                    request.PageSize).ConfigureAwait(false);

                return new PaginatedToDoItemsResponse(
                    data,
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
