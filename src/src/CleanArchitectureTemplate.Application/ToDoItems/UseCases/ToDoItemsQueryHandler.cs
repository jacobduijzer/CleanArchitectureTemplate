using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.ToDoItems.UseCases
{
    public class ToDoItemsQueryHandler
        : IRequestHandler<ToDoItemsQuery, IEnumerable<ToDoItem>>
    {
        private readonly IRepository<ToDoItem> _repository;

        public ToDoItemsQueryHandler(IRepository<ToDoItem> repository) =>
            _repository = repository;

        public async Task<IEnumerable<ToDoItem>> Handle(ToDoItemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository
                    .GetAsync(request.Specification.AsExpression())
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Add error logging here
            }

            return null;
        }
    }
}
