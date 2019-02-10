using CleanArchitectureTemplate.Domain.Shared;
using CleanArchitectureTemplate.Domain.ToDoItems;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.ToDoItems
{
    public class CachedToDoItemRepositoryDecorator
        : IReadOnlyRepository<ToDoItem>
    {
        private readonly IRepository<ToDoItem> repository;
        private readonly IMemoryCache cache;
        private readonly MemoryCacheEntryOptions cacheOptions;

        private const string MyModelCacheKey = "ToDoItems";

        // TODO: move to settings
        private const int DefaultCacheSeconds = 15;

        public CachedToDoItemRepositoryDecorator(
            IRepository<ToDoItem> repository,
            IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;

            cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(DefaultCacheSeconds));
        }

        public async Task<ToDoItem> GetFirstItemAsync(ICacheableDataSpecification<ToDoItem> specification)
        {   
            return await cache.GetOrCreate(specification.CacheKey, async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await repository.GetFirstItemAsync(specification).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<int> GetItemCountAsync(ICacheableDataSpecification<ToDoItem> specification)
        {
            return await cache.GetOrCreate(specification.CacheKey, async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await repository.GetItemCountAsync(specification).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(ICacheableDataSpecification<ToDoItem> specification)
        {
            //Func<IEnumerable<ToDoItem>> createValue = () => repository.GetItemsAsync(specification);
            Func<ICacheEntry, Task<IEnumerable<ToDoItem>>> taskFunc = entry => repository.GetItemsAsync(specification);
            var data1 = await cache.GetOrCreateAsync(specification.CacheKey, taskFunc);
            //var data1 = await cache.GetOrCreateAsync(specification.CacheKey, async cacheEntry =>
            // {
            //     cacheEntry.SetOptions(cacheOptions);
            //     var data2 = await repository.GetItemsAsync(specification).ConfigureAwait(false);
            //     return data2;
            // }).ConfigureAwait(false);
            return data1;
        }

        public async Task<ToDoItem> GetSingleItemAsync(ICacheableDataSpecification<ToDoItem> specification)
        {
            return await cache.GetOrCreateAsync(specification.CacheKey, async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await repository.GetSingleItemAsync(specification).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
