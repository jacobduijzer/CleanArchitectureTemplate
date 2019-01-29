using System;
using System.Linq.Expressions;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class AllToDoItems : Specification<ToDoItem>
    {
        public override Expression<Func<ToDoItem, bool>> AsExpression() =>
            item => true;
    }
}
