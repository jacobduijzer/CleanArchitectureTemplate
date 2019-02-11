using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using LinqBuilder;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.ToDoItems.Specifications
{
    public class AllToDoItems 
        : ICacheableDataSpecification<ToDoItem>
    {
        public string CacheKey => 
            $"{nameof(AllToDoItems)}-item-true"; 
                    
        public ISpecification<ToDoItem> Specification => 
            Spec<ToDoItem>.New(item => true);
    }
}
