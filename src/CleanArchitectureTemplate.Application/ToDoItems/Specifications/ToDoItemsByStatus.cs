using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class ToDoItemsByStatus 
        : ICacheableDataSpecification<ToDoItem> 
    {
        private readonly bool status;

        public ToDoItemsByStatus(bool status) =>
            this.status = status;

        public string CacheKey =>
            $"{nameof(ToDoItemsByStatus)}-status-{status}";

        public ISpecification<ToDoItem> Specification =>
             Spec<ToDoItem>.New(item => item.IsDone == status);
    }
}
