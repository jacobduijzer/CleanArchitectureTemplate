using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;
using LinqBuilder.OrderBy;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Shared
{
    public class BasePagedHandler<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> repository;

        public BasePagedHandler(IRepository<TEntity> repository) =>
            this.repository = repository;

        public async Task<bool> HasPreviousPage(
            ISpecification<TEntity> specification, 
            int pageNumber, 
            int pageSize)
        {
            if (pageNumber == 1)
                return false;

            var count = await repository
                .GetItemCountAsync(specification.Paginate(pageNumber - 1, pageSize))
                .ConfigureAwait(false);

            return count > 0;
        }

        public async Task<bool> HasNextPage(
            ISpecification<TEntity> specification,
            int pageNumber,
            int pageSize)
        {
            var count = await repository
                .GetItemCountAsync(specification.Paginate(pageNumber + 1, pageSize))
                .ConfigureAwait(false);

            return count > 0;
        }
    }
}
