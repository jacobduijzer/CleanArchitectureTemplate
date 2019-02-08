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
    public class PaginatedToDoModel : PageModel
    {
        private readonly IMediator mediator;

        public PaginatedToDoModel(IMediator mediator)
            => this.mediator = mediator;

        public IList<ToDoItem> ToDoItems { get; private set; }

        public int PageNumber { get; private set; }

        public int PreviousPageNumber => PageNumber > 1 ? PageNumber - 1 : 1;

        public int NextPageNumber => PageNumber + 1;

        public async Task OnGetAsync(int pageNumber = 1)
        {
            var response = await mediator
                .Send(new PaginatedToDoItemsRequest(new AllToDoItems(), pageNumber, 10))
                .ConfigureAwait(false);

            if (response.IsSuccessful)
            {
                ToDoItems = response.ToDoItems.ToList();
                PageNumber = response.PageNumber;
            }
        }
    }
}