using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using CleanArchitectureTemplate.Infrastructure.Shared;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Infrastructure.Shared
{
    public class CachedRepositoryDecoratorShould
    {
        private readonly Mock<IRepository<ToDoItem>> mockToDoRepository;
        private readonly Mock<IMemoryCache> mockCache;
        private readonly IApplicationSettings applicationSettings;

        public CachedRepositoryDecoratorShould()
        {
            mockToDoRepository = new Mock<IRepository<ToDoItem>>();
            mockCache = new Mock<IMemoryCache>();
            applicationSettings = ApplicationSettings.Builder
                .WithCacheDuration(TimeSpan.FromSeconds(30))
                .Build();
        }

        [Fact]
        public void Construct() =>
            new CachedRepositoryDecorator<ToDoItem>(
                mockToDoRepository.Object,
                mockCache.Object,
                applicationSettings)
                .Should().BeOfType<CachedRepositoryDecorator<ToDoItem>>();
    }
}
