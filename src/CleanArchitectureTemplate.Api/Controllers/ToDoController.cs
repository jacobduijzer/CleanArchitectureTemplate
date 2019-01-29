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
        private readonly IMediator _mediator;
        public ToDoController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            var result = await _mediator.Send(new ToDoItemsRequest(new AllToDoItems())).ConfigureAwait(false);

            if (result != null && result.ToDoItems.Any())
                return result.ToDoItems.ToList();

            // TODO
            throw new InvalidOperationException("TODO: error handling");
        }
    }
}
