using CleanArchitectureTemplate.Domain.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class CachedRepositoryDecorator<TEntity>
        : IReadOnlyRepository<TEntity>
            where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> repository;
        private readonly IMemoryCache cache;
        private readonly MemoryCacheEntryOptions cacheOptions;

        // TODO: move to settings
        private const int DefaultCacheSeconds = 15;

        public CachedRepositoryDecorator(
            IRepository<TEntity> repository,
            IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;

            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(DefaultCacheSeconds));
        }

        public async Task<TEntity> GetFirstItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<TEntity>(specification.CacheKey, () => repository.GetFirstItemAsync(specification))
            .ConfigureAwait(false);

        public async Task<int> GetItemCountAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<int>(specification.CacheKey, () => repository.GetItemCountAsync(specification))
            .ConfigureAwait(false);

        public async Task<IEnumerable<TEntity>> GetItemsAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<IEnumerable<TEntity>>(specification.CacheKey, () => repository.GetItemsAsync(specification))
            .ConfigureAwait(false);

        public async Task<TEntity> GetSingleItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<TEntity>(specification.CacheKey, () => repository.GetSingleItemAsync(specification))
            .ConfigureAwait(false);

        private async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> repositoryCall) =>
            await cache.GetOrCreateAsync<T>(cacheKey, async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await repositoryCall().ConfigureAwait(false);
            }).ConfigureAwait(false);
    }
}
