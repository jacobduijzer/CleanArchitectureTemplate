using CleanArchitectureTemplate.IntegrationTests.Helpers;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Web;
using Xunit;

namespace CleanArchitectureTemplate.IntegrationTests.Web.Pages
{
    public class ToDoShould : BasePageTest<Startup>
    {
        public ToDoShould(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnOk()
        {
            var response = await HttpClient.GetAsync("/todo");
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
