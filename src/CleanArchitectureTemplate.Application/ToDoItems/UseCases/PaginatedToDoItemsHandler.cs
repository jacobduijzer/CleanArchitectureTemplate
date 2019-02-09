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
        : IRequestHandler<PaginatedToDoItemsRequest, PaginatedToDoItemsResponse>
    {
        private readonly IRepository<ToDoItem> _repository;

        public PaginatedToDoItemsHandler(IRepository<ToDoItem> repository) =>
            _repository = repository;

        public async Task<PaginatedToDoItemsResponse> Handle(
            PaginatedToDoItemsRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await _repository.GetItemsAsync(
                    request.Specification.Paginate(request.PageNumber, request.PageSize)
                ).ConfigureAwait(false);

                // TODO: think about moving to BasePaginatedHandler?
                // has records before current result?
                int previousRecordCount = 0;
                if (request.PageNumber != 1)
                {
                    previousRecordCount = await _repository.GetItemCountAsync(
                        request.Specification.Paginate(request.PageNumber - 1, request.PageSize)
                    ).ConfigureAwait(false);
                }

                // TODO: think about moving to BasePaginatedHandler?
                // has records after current result?
                var nextRecordCount = await _repository.GetItemCountAsync(
                    request.Specification.Paginate(request.PageNumber + 1, request.PageSize)
                ).ConfigureAwait(true);

                return new PaginatedToDoItemsResponse(
                    response, 
                    previousRecordCount > 0,
                    nextRecordCount > 0,
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
