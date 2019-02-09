using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Web.Pages
{
    public class PaginatedToDoModel : PageModel
    {
        private readonly IMediator mediator;

        public PaginatedToDoModel(IMediator mediator)
            => this.mediator = mediator;

        public PaginatedToDoItemsResponse Result { get; private set; }

        public int PreviousPageNumber =>
            Result.CurrentPageNumber > 1 ? Result.CurrentPageNumber - 1 : 1;

        public int NextPageNumber => 
            Result.CurrentPageNumber + 1;

        public async Task OnGetAsync(int pageNumber = 1)
        {
            var response = await mediator
                .Send(new PaginatedToDoItemsRequest(new AllToDoItems(), pageNumber, 10))
                .ConfigureAwait(false);

            if (response.IsSuccessful)
                Result = response;
        }
    }
}