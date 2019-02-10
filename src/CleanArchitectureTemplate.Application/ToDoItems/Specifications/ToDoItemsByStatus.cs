using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class ToDoItemsByStatus : ICacheableDataSpecification<ToDoItem> 
    {
        private readonly bool status;
        public ToDoItemsByStatus(bool status)
        {
            this.status = status;
            specification = Spec<ToDoItem>.New(item => item.IsDone == status);
        }

        public string CacheKey => $"{nameof(ToDoItemsByStatus)}-status-{status}";

        private ISpecification<ToDoItem> specification; 
        public ISpecification<ToDoItem> Specification
        {
            get => specification;
            set => specification = value;
        }

        public void AddStringToCacheKey(string addition)
        {
            throw new System.NotImplementedException();
        }
    }
}
