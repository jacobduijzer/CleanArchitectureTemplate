using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Web.Pages;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Web.Pages
{
    public class ToDoModelShould
    {
        [Fact]
        public async Task CallAsyncHandler()
        {
            var mockMediator = new Mock<IMediator>();

            var viewModel = new ToDoModel(mockMediator.Object);
            await viewModel.OnGetAsync();

            mockMediator.Verify(x => x.Send(It.IsAny<ToDoItemsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
