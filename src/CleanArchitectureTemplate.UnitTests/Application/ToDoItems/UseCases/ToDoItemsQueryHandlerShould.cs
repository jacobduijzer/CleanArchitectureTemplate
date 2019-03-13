using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.FakeData.ToDoItems;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class ToDoItemsQueryHandlerShould
    {
        private readonly Mock<IRepository<ToDoItem>> _mockToDoRepository;

        public ToDoItemsQueryHandlerShould()
        {
            _mockToDoRepository = new Mock<IRepository<ToDoItem>>();
            _mockToDoRepository
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(ToDoItemData.ToDoItemsForTesting)
                .Verifiable();
        }

        [Fact]
        public void Construct() =>
            new ToDoItemsQueryHandler(_mockToDoRepository.Object).Should().BeOfType<ToDoItemsQueryHandler>();

        [Fact]
        public async Task CallRepositoryWhenHandling()
        {
            var handler = new ToDoItemsQueryHandler(_mockToDoRepository.Object);
            await handler
                .Handle(new ToDoItemsQuery(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            _mockToDoRepository.Verify(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()), Times.Once);
        }

        [Fact]
        public async Task ReturnSuccessFalseOnError()
        {
            var mockRepo = new Mock<IRepository<ToDoItem>>();
            mockRepo
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ThrowsAsync(new System.Exception("Error"))
                .Verifiable();

            var handler = new ToDoItemsQueryHandler(mockRepo.Object);
            var result = await handler
                .Handle(new ToDoItemsQuery(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            mockRepo.Verify(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()), Times.Once);
            result.Should().BeNull();
        }

        [Fact]
        public async Task ReturnToDoItem()
        {
            var handler = new ToDoItemsQueryHandler(_mockToDoRepository.Object);
            var response = await handler
                .Handle(new ToDoItemsQuery(new AllToDoItems()), new System.Threading.CancellationToken())
                .ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().NotBeNullOrEmpty()
                .And.HaveCount(6);
        }
    }
}
