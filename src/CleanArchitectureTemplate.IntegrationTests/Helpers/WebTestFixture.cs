using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using CleanArchitectureTemplate.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net.Http;

namespace CleanArchitectureTemplate.IntegrationTests.Helpers
{
    public class WebTestFixture
        : WebApplicationFactory<Startup>
    {
        public WebTestFixture()
        {
            HttpClient = WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var mockReadonlyToDoRepository = new Mock<IReadOnlyRepository<ToDoItem>>(MockBehavior.Strict);
                    mockReadonlyToDoRepository
                    .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                    .ReturnsAsync(ToDoItemData.ToDoItemsForTesting);

                    var mockToDoRepository = new Mock<IRepository<ToDoItem>>(MockBehavior.Strict);
                    mockToDoRepository
                    .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                    .ReturnsAsync(ToDoItemData.ToDoItemsForTesting);

                    services.AddSingleton<IReadOnlyRepository<ToDoItem>>(factory => mockReadonlyToDoRepository.Object);
                    services.AddSingleton<IRepository<ToDoItem>>(factory => mockToDoRepository.Object);
                });
            }).CreateClient();
        }

        public HttpClient HttpClient { get; private set; }
    }
}
