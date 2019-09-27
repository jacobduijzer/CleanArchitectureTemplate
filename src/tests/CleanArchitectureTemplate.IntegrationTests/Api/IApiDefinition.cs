using CleanArchitectureTemplate.Domain.ToDoItems;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.IntegrationTests.Api
{
    public interface IApiDefinition
    {
        [Get("/api/todo")]
        Task<List<ToDoItem>> GetAllToDoItems();
    }
}
