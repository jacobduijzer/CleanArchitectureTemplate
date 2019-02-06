using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsHandler : IRequestHandler<ToDoItemsRequest, ToDoItemsResponse>
    {
        private readonly IRepository<ToDoItem> _repository;

        public ToDoItemsHandler(IRepository<ToDoItem> repository) =>
            _repository = repository;

        public async Task<ToDoItemsResponse> Handle(ToDoItemsRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetItemsAsync(request.Specification).ConfigureAwait(false);
            if (response != null)
                return new ToDoItemsResponse(response);

            return new ToDoItemsResponse(false);
        }
    }
}
