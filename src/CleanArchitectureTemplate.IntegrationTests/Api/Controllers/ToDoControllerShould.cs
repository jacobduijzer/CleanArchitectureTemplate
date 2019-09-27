using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Api;
using Refit;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Api.Controllers
{
    public class ToDoControllerShould : BaseIntegrationTest<Startup>
    {
        private readonly IApiDefinition _api;

        public ToDoControllerShould(CustomWebApplicationFactory<Startup> factory) : base(factory) =>
            _api = RestService.For<IApiDefinition>(HttpClient);

        [Fact]
        public async Task ReturnOk()
        {
            var result = await HttpClient.GetAsync("/api/todo");
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ReturnItems()
        {
            var result = await _api.GetAllToDoItems();
            result.Should().NotBeNullOrEmpty().And.HaveCount(6);
        }
    }
}
