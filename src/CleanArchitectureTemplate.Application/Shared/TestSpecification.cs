using Ardalis.GuardClauses;
using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;

namespace CleanArchitectureTemplate.Application.Shared
{
    public class TestSpecification<TEntity>
        : ICacheableDataSpecification<TEntity>
            where TEntity : BaseEntity
    {
        public TestSpecification(ISpecification<TEntity> specification, string cacheKey)
        {
            Guard.Against.Null(specification, "Specification");
            Guard.Against.NullOrEmpty(cacheKey, "CacheKey");

            this.cacheKey = cacheKey;
            Specification = specification;
        }

        private string cacheKey;
        public string CacheKey => cacheKey;

        public ISpecification<TEntity> Specification { get; private set; }
    }
}
