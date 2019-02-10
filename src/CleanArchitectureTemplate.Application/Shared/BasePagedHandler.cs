using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;
using LinqBuilder.OrderBy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Shared
{
    public class BasePagedHandler<TEntity> where TEntity : BaseEntity
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
            specification.AddStringToCacheKey($"{pageNumber}-{pageSize}");
            specification.Specification = specification.Specification.Paginate(pageNumber, pageSize);

            return await Repository
                .GetItemsAsync(specification)
                .ConfigureAwait(false);
        }

        public async Task<bool> HasPreviousPage(
            ICacheableDataSpecification<TEntity> specification, 
            int pageNumber, 
            int pageSize)
        {
            if (pageNumber == 1)
                return false;

            specification.AddStringToCacheKey($"{pageNumber}-{pageSize}");
            specification.Specification = specification.Specification.Paginate(pageNumber - 1, pageSize);

            var count = await Repository
                .GetItemCountAsync(specification)
                .ConfigureAwait(false);

            return count > 0;
        }

        public async Task<bool> HasNextPage(
            ICacheableDataSpecification<TEntity> specification,
            int pageNumber,
            int pageSize)
        {
            specification.AddStringToCacheKey($"{pageNumber}-{pageSize}");
            specification.Specification = specification.Specification.Paginate(pageNumber + 1, pageSize);

            var count = await Repository
                .GetItemCountAsync(specification)
                .ConfigureAwait(false);

            return count > 0;
        }
    }
}
