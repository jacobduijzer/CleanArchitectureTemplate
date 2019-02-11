using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Infrastructure.Shared
{
    public class CachedRepositoryDecoratorShould
    {
        private readonly Mock<IRepository<ToDoItem>> mockToDoRepository;
        private readonly Mock<IMemoryCache> mockCache;

        public CachedRepositoryDecoratorShould()
        {
            mockToDoRepository = new Mock<IRepository<ToDoItem>>();
            mockCache = new Mock<IMemoryCache>();
        }

        [Fact]
        public void Construct() =>
            new CachedRepositoryDecorator<ToDoItem>(
                mockToDoRepository.Object,
                mockCache.Object)
                .Should().BeOfType<CachedRepositoryDecorator<ToDoItem>>();
    }
}
