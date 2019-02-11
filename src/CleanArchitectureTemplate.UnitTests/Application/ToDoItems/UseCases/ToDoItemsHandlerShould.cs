using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using FluentAssertions;
using LinqBuilder.Core;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class ToDoItemsHandlerShould
    {
        private readonly Mock<IRepository<ToDoItem>> mockToDoRepository;

        public ToDoItemsHandlerShould()
        {
            mockToDoRepository = new Mock<IRepository<ToDoItem>>();
            mockToDoRepository
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(ToDoItemData.ToDoItemsForTesting)
                .Verifiable();
        }

        [Fact]
        public void Construct() =>
            new ToDoItemsHandler(mockToDoRepository.Object).Should().BeOfType<ToDoItemsHandler>();

        [Fact]
        public async Task CallRepositoryWhenHandling()
        {
            var handler = new ToDoItemsHandler(mockToDoRepository.Object);
            await handler
                .Handle(new ToDoItemsRequest(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            mockToDoRepository.Verify(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()), Times.Once);
        }

        [Fact]
        public async Task ReturnSuccessFalseOnError()
        {
            var mockRepo = new Mock<IRepository<ToDoItem>>();
            mockRepo
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ThrowsAsync(new System.Exception("Error"))
                .Verifiable();

            var handler = new ToDoItemsHandler(mockRepo.Object);
            var result = await handler
                .Handle(new ToDoItemsRequest(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            mockRepo.Verify(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()), Times.Once);
            result.IsSuccessful.Should().BeFalse();
            result.Message.Should().Be("Error");
        }

        [Fact]
        public async Task ReturnToDoItem()
        {
            var handler = new ToDoItemsHandler(mockToDoRepository.Object);
            var response = await handler
                .Handle(new ToDoItemsRequest(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            response.Should().NotBeNull();
            response.IsSuccessful.Should().BeTrue();
            response.ToDoItems.Should().NotBeNullOrEmpty()
                .And.HaveCount(6);
        }
    }
}
