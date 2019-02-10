using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using LinqBuilder.Core;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsHandlerShould
    {
        private readonly Mock<IRepository<ToDoItem>> mockToDoItemRepo;
        private readonly List<ToDoItem> fakeData;

        public PaginatedToDoItemsHandlerShould()
        {
            fakeData = FakeData.ToDoItems.ToDoItemData.GenerateTestData(100);

            mockToDoItemRepo = new Mock<IRepository<ToDoItem>>();
            mockToDoItemRepo
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(fakeData.GetRange(0, 10));
        }

        [Fact]
        public void Construct() =>
            new PaginatedToDoItemsHandler(mockToDoItemRepo.Object)
                .Should().BeOfType<PaginatedToDoItemsHandler>();

        [Fact]
        public async Task HandleFirstPageResult()
        {
            mockToDoItemRepo
                .Setup(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10);

            var handler = new PaginatedToDoItemsHandler(mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsRequest(new AllToDoItems(), 1, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeFalse();
            result.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task HandleMiddlePageResult()
        {
            mockToDoItemRepo
                .Setup(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10);

            var handler = new PaginatedToDoItemsHandler(mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsRequest(new AllToDoItems(), 3, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeTrue();
            result.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task HandleLastPageResult()
        {
            mockToDoItemRepo
                .SetupSequence(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10)
                .ReturnsAsync(0);

            var handler = new PaginatedToDoItemsHandler(mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsRequest(new AllToDoItems(), 9, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeTrue();
            result.HasNextPage.Should().BeFalse();
        }
    }
}
