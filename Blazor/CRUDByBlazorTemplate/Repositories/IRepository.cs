using CRUDByBlazorTemplate.Utils;
using System.Linq.Expressions;

namespace CRUDByBlazorTemplate.Repository
{
    public interface IRepository<T> where T : class
    {

        public Task<Pagination<T>> Get(int skip, int take, string? search, IQueryable<T>? customQuery);

        public Task<T> GetById(Guid Id, Expression<Func<T, object>>[] includes);

        public Task<T> Post(T entity);

        public Task<T> Patch(T entity);

        public Task<Boolean> Delete(T entity);
        

    }
}
