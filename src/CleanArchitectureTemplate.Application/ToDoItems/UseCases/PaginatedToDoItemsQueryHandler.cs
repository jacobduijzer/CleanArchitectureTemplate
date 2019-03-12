using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsQueryHandler
        : BasePagedHandler<ToDoItem>, IRequestHandler<PaginatedToDoItemsQuery, PaginatedToDoItems>
    {
        public PaginatedToDoItemsQueryHandler(IReadOnlyRepository<ToDoItem> repository)
            : base(repository)
        { }

        public async Task<PaginatedToDoItems> Handle(
            PaginatedToDoItemsQuery request,
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

                return new PaginatedToDoItems(
                    data,
                    hasPreviousRecords,
                    hasNextRecords,
                    request.PageNumber);
            }
            catch (Exception ex)
            {
                // TODO: Error handling
            }

            return null;
        }
    }
}
