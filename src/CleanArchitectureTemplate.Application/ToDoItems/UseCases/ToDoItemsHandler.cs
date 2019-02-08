using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsHandler : IRequestHandler<ToDoItemsRequest, ToDoItemsResponse>
    {
        private readonly IRepository<ToDoItem> repository;

        public ToDoItemsHandler(IRepository<ToDoItem> repository) =>
            this.repository = repository;

        public async Task<ToDoItemsResponse> Handle(ToDoItemsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await repository.GetItemsAsync(request.Specification).ConfigureAwait(false);
                return new ToDoItemsResponse(response);
            }
            catch (Exception ex)
            {
                // Add error logging here

                return new ToDoItemsResponse(false, ex.Message);
            }
        }
    }
}
