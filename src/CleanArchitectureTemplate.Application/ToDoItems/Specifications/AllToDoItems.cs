using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class AllToDoItems : ICacheableDataSpecification<ToDoItem>
    {
        private readonly string baseCacheKey = $"{nameof(AllToDoItems)}-item-true";

        private string cacheKey;
        public string CacheKey => 
            !string.IsNullOrEmpty(cacheKey) ?
                $"{baseCacheKey}-{cacheKey}" :
                    baseCacheKey;
                    
        private ISpecification<ToDoItem> specification = Spec<ToDoItem>.New(item => true);
        public ISpecification<ToDoItem> Specification
        {
            get => specification;
            set => specification = value;
        }

        public void AddStringToCacheKey(string addition) =>
            cacheKey = addition;
    }
}
