using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface ICacheableDataSpecification<TEntity> 
        where TEntity : EntityBase
    { 
        string CacheKey { get; }

        ISpecification<TEntity> Specification { get; }
    }
}
