using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.Shared
{
    internal class SpecialSpecification<TEntity>
        : ICacheableDataSpecification<TEntity>
            where TEntity : EntityBase
    {
        private readonly string cacheKey;

        internal SpecialSpecification(ISpecification<TEntity> specification, string cacheKey)
        {
            Guard.Against.Null(specification, "Specification");
            Guard.Against.NullOrEmpty(cacheKey, "CacheKey");

            this.cacheKey = cacheKey;
            Specification = specification;
        }
        
        public string CacheKey => cacheKey;

        public ISpecification<TEntity> Specification { get; private set; }
    }
}
