using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using CleanArchitectureTemplate.Domain.ToDoItems;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class PaginatedToDoItemsShould
    {
        [Fact]
        public void Construct() =>
            new PaginatedToDoItems(new List<ToDoItem>(), false, false, 1)
                .Should().BeOfType<PaginatedToDoItems>();
    }
}
