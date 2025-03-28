using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Utils;

namespace BiblioASPNet.Application.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {

        public Task<T> CreateAsync(T entity);

        public Task<Pagination<T>> ListAsync(int skip, int take, string search);

        public Task<T?> GetByIdAsync(Guid id);

        public Task<T> UpdateAsync(T entity);

        public Task<bool> DeleteAsync(T entity);


    }
}
