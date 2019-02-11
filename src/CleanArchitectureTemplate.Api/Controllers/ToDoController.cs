using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using System.Linq;

namespace CleanArchitectureTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController
    {
        private const int ItemsPerPage = 10;

        private readonly IMediator mediator;

        public ToDoController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            var result = await mediator.Send(new ToDoItemsRequest(new AllToDoItems())).ConfigureAwait(false);

            if (result != null && result.IsSuccessful)
                return result.ToDoItems.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpGet]
        [Route("{pageNumber:int}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetPaged(int pageNumber)
        {
            var result = await mediator
                .Send(new PaginatedToDoItemsRequest(new AllToDoItems(), pageNumber, ItemsPerPage))
                .ConfigureAwait(false);

            if (result != null && result.IsSuccessful)
                return result.ToDoItems.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpGet]
        [Route("{status:bool}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetByStatus(bool status)
        {
            var result = await mediator
                .Send(new ToDoItemsRequest(new ToDoItemsByStatus(status)))
                .ConfigureAwait(false);

            if (result != null && result.IsSuccessful)
                return result.ToDoItems.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }
    }
}
