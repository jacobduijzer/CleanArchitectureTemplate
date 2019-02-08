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

                return new PaginatedToDoItemsResponse(response, request.PageNumber);
            }
            catch (Exception ex)
            {
                // TODO: Error handling
                return new PaginatedToDoItemsResponse(false, ex.Message);
            }
        }
    }
}
