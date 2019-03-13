using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.OrderBy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Shared
{
    public class BasePagedHandler<TEntity> where TEntity : Entity
    {
        protected readonly IReadOnlyRepository<TEntity> Repository;

        public BasePagedHandler(IReadOnlyRepository<TEntity> repository) =>
            Repository = repository;

        public async Task<IEnumerable<TEntity>> GetItemsAsync(
            ICacheableDataSpecification<TEntity> specification,
            int pageNumber,
            int pageSize
            )
        {
            var spec1 = new SpecialSpecification<TEntity>(
                specification.Specification.Paginate(pageNumber, pageSize),
                specification.CacheKey + $"-{pageNumber}-{pageSize}");

            return await Repository
                .GetItemsAsync(spec1)
                .ConfigureAwait(false);
        }

        public async Task<bool> HasPreviousPage(
            ICacheableDataSpecification<TEntity> specification,
            int pageNumber,
            int pageSize)
        {
            if (pageNumber == 1)
                return false;

            var spec2 = new SpecialSpecification<TEntity>(
                specification.Specification.Paginate(pageNumber - 1, pageSize),
                specification.CacheKey + $"-{pageNumber - 1}-{pageSize}-HasPreviousPage");

            var count = await Repository
                .GetItemCountAsync(spec2)
                .ConfigureAwait(false);

            return count > 0;
        }

        public async Task<bool> HasNextPage(
            ICacheableDataSpecification<TEntity> specification,
            int pageNumber,
            int pageSize)
        {
            var spec3 = new SpecialSpecification<TEntity>(
                specification.Specification.Paginate(pageNumber + 1, pageSize),
                specification.CacheKey + $"-{pageNumber + 1}-{pageSize}-HasNextPage");

            var count = await Repository
                .GetItemCountAsync(spec3)
                .ConfigureAwait(false);

            return count > 0;
        }
    }
}
