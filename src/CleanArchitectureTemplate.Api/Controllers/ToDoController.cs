using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController
    {
        private const int ITEMSPERPAGE = 10;

        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            var result = await _mediator.Send(new ToDoItemsQuery(new AllToDoItems())).ConfigureAwait(false);

            if (result != null && result.Any())
                return result.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpGet]
        [Route("{pageNumber:int}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetPaged(int pageNumber)
        {
            var result = await _mediator
                .Send(new PaginatedToDoItemsQuery(new AllToDoItems(), pageNumber, ITEMSPERPAGE))
                .ConfigureAwait(false);

            if (result != null && result.ToDoItems.Any())
                return result.ToDoItems.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpGet]
        [Route("{status:bool}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetByStatus(bool status)
        {
            var result = await _mediator
                .Send(new ToDoItemsQuery(new ToDoItemsByStatus(status)))
                .ConfigureAwait(false);

            if (result != null && result.Any())
                return result.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }
    }
}
