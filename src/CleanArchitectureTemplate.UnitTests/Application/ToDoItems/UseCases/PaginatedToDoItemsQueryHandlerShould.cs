using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsQueryHandlerShould
    {
        private readonly Mock<IRepository<ToDoItem>> _mockToDoItemRepo;
        private readonly List<ToDoItem> _fakeData;

        public PaginatedToDoItemsQueryHandlerShould()
        {
            _fakeData = FakeData.ToDoItems.ToDoItemData.GenerateTestData(100);

            _mockToDoItemRepo = new Mock<IRepository<ToDoItem>>();
            _mockToDoItemRepo
                .Setup(x => x.GetItemsAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(_fakeData.GetRange(0, 10));
        }

        [Fact]
        public void Construct() =>
            new PaginatedToDoItemsQueryHandler(_mockToDoItemRepo.Object)
                .Should().BeOfType<PaginatedToDoItemsQueryHandler>();

        [Fact]
        public async Task HandleFirstPageResult()
        {
            _mockToDoItemRepo
                .Setup(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10);

            var handler = new PaginatedToDoItemsQueryHandler(_mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsQuery(new AllToDoItems(), 1, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeFalse();
            result.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task HandleMiddlePageResult()
        {
            _mockToDoItemRepo
                .Setup(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10);

            var handler = new PaginatedToDoItemsQueryHandler(_mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsQuery(new AllToDoItems(), 3, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeTrue();
            result.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task HandleLastPageResult()
        {
            _mockToDoItemRepo
                .SetupSequence(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .ReturnsAsync(10)
                .ReturnsAsync(0);

            var handler = new PaginatedToDoItemsQueryHandler(_mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsQuery(new AllToDoItems(), 9, 10), new CancellationToken())
                .ConfigureAwait(false);

            result.Should().NotBeNull();
            result.ToDoItems.Should().NotBeNullOrEmpty();
            result.HasPreviousPage.Should().BeTrue();
            result.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task ReturnFalseWhenExceptionOccurs()
        {
            _mockToDoItemRepo
                .Setup(x => x.GetItemCountAsync(It.IsAny<ICacheableDataSpecification<ToDoItem>>()))
                .Throws(new Exception("Test exception"));

            var handler = new PaginatedToDoItemsQueryHandler(_mockToDoItemRepo.Object);
            var result = await handler
                .Handle(new PaginatedToDoItemsQuery(new AllToDoItems(), 9, 10), new CancellationToken())
                .ConfigureAwait(false);
            result.ToDoItems.Should().BeNull();
        }
    }
}
