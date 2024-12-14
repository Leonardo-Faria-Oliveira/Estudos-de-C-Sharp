using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Services
{
    public interface IBaseService<T, J> where T : class
    {
        public Task<T> Get(int skip, int take, string? search);

        public Task<T> GetById(Guid Id);

        public Task<T> Post(J entity);

        public Task<T> Patch(Guid id, J entity);

        public Task<T> Delete(Guid id);
    }
}
