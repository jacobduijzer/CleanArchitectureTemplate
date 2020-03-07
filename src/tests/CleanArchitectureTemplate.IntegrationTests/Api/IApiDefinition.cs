using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.ToDoItems;

namespace CleanArchitectureTemplate.IntegrationTests.Api
{
    public interface IApiDefinition
    {
        [Get("/api/todo")]
        Task<List<ToDoItem>> GetAllToDoItems();
    }
}
