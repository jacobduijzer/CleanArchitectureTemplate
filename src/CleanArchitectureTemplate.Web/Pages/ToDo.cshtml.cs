using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Web.Pages
{
    public class ToDoModel : PageModel
    {
        private readonly IMediator _mediator;

        public ToDoModel(IMediator mediator)
            => _mediator = mediator;

        public IList<ToDoItem> ToDoItems { get; private set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            var result = await _mediator
                .Send(new ToDoItemsRequest(new AllToDoItems()))
                .ConfigureAwait(false);

            if (result != null)
                ToDoItems = result.ToDoItems.ToList();
        }
    }
}
