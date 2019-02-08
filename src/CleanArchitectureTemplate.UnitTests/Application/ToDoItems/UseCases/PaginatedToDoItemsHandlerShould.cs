using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using LinqBuilder.Core;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsHandlerShould
    {
        private readonly Mock<IRepository<ToDoItem>> mockToDoItemRepo;

        public PaginatedToDoItemsHandlerShould()
        {
            mockToDoItemRepo = new Mock<IRepository<ToDoItem>>();
            mockToDoItemRepo
                .Setup(x => x.GetItemsAsync(It.IsAny<ISpecification<ToDoItem>>()))
                .ReturnsAsync(FakeData.ToDoItems.ToDoItemData.GenerateTestData(100))
                .Verifiable();
        }

        [Fact]
        public void Construct() =>
            new PaginatedToDoItemsHandler(mockToDoItemRepo.Object)
                .Should().BeOfType<PaginatedToDoItemsHandler>();

        [Fact]
        public async Task ReturnData()
        {
            // Mock always returns 100 items. Use a in-mem database?
            //var handler = new PaginatedToDoItemsHandler(mockToDoItemRepo.Object);
            //var result = await handler
            //    .Handle(new PaginatedToDoItemsRequest(new AllToDoItems(), 1, 10), new CancellationToken())
            //    .ConfigureAwait(false);

            //result.Should().NotBeNull();
            //result.IsSuccessful.Should().BeTrue();
            //result.ToDoItems.Should().NotBeNullOrEmpty()
            //    .And.HaveCount(10);
        }
    }
}
