using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Api.ToDoItems
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private const int ITEMSPERPAGE = 10;

        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ToDoItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            var result = await _mediator.Send(new ToDoItemsQuery(new AllToDoItems())).ConfigureAwait(false);

            if (result != null && result.Any())
                return result.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpGet]
        [Route("{status:bool}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ToDoItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetByStatus(bool status)
        {
            var result = await _mediator
                .Send(new ToDoItemsQuery(new ToDoItemsByStatus(status)))
                .ConfigureAwait(false);

            if (result != null && result.Any())
                return result.ToList();

            throw new InvalidOperationException("TODO: error handling");
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateToDoItem([FromBody]CreateToDoItemRequest newTodoItem)
        {
            var newToDoItemId = await _mediator.Send(new CreateToDoItemCommand(newTodoItem));

            return Created(string.Empty, newToDoItemId);
        }
    }
}
