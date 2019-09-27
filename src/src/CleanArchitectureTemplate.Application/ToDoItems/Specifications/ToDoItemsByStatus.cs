using System;
using System.Linq.Expressions;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class ToDoItemsByStatus : QuerySpecification<ToDoItem>
    {
        private readonly bool status;

        public ToDoItemsByStatus(bool status) =>
            this.status = status;

        public override Expression<Func<ToDoItem, bool>> AsExpression() =>
            item => item.IsDone == status;
    }
}
