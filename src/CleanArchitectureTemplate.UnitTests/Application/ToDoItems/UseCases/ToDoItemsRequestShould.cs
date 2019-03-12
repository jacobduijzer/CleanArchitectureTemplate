using CleanArchitectureTemplate.Application.ToDoItems.Specifications;
using CleanArchitectureTemplate.Application.ToDoItems.UseCases;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Application.ToDoItems.UseCases
{
    public class ToDoItemsRequestShould
    {
        [Fact]
        public void Construct() =>
            new ToDoItemsQuery(new AllToDoItems())
                .Should().BeOfType<ToDoItemsQuery>();

        [Fact]
        public void ThrowWhenSpecificationIsNull() =>
            new Action(() => new ToDoItemsQuery(null))
                .Should().Throw<ArgumentNullException>()
                    .WithMessage("*Specification*");

    }
}
