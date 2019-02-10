using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Domain.Shared
{
    public interface ICacheableDataSpecification<TEntity> 
        where TEntity : BaseEntity
    { 
        string CacheKey { get; }

        ISpecification<TEntity> Specification { get; set; }

        void AddStringToCacheKey(string addition);
    }
}
