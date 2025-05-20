using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    public interface IRepository<T>
    {

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);

        T Find(object id);


    }
}
