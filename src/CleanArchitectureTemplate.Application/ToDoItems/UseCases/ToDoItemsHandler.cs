using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;
using MediatR;

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
            if (response != null && response.Any())
                return new ToDoItemsResponse(response);

            throw new InvalidOperationException("TODO good handling");
        }
    }
}
