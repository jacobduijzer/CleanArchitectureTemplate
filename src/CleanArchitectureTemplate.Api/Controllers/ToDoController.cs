using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.ToDoItems;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
