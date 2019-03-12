using CleanArchitectureTemplate.Application.Shared;
using CleanArchitectureTemplate.Domain.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class CachedRepositoryDecorator<TEntity>
        : IReadOnlyRepository<TEntity>
            where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public CachedRepositoryDecorator(
            IRepository<TEntity> repository,
            IMemoryCache cache,
            IApplicationSettings applicationSettings)
        {
            _repository = repository;
            _cache = cache;
            _cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: applicationSettings.CacheDuration);
        }

        public async Task<TEntity> GetFirstItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<TEntity>(specification.CacheKey, () => _repository.GetFirstItemAsync(specification))
            .ConfigureAwait(false);

        public async Task<int> GetItemCountAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<int>(specification.CacheKey, () => _repository.GetItemCountAsync(specification))
            .ConfigureAwait(false);

        public async Task<IEnumerable<TEntity>> GetItemsAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<IEnumerable<TEntity>>(specification.CacheKey, () => _repository.GetItemsAsync(specification))
            .ConfigureAwait(false);

        public async Task<TEntity> GetSingleItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await GetAsync<TEntity>(specification.CacheKey, () => _repository.GetSingleItemAsync(specification))
            .ConfigureAwait(false);

        private async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> repositoryCall) =>
            await _cache.GetOrCreateAsync<T>(cacheKey, async entry =>
            {
                entry.SetOptions(_cacheOptions);
                return await repositoryCall().ConfigureAwait(false);
            }).ConfigureAwait(false);
    }
}
