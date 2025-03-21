using BiblioASPNet.Application.Requests;

namespace BiblioASPNet.Application.Services
{
    public interface IService<S, J, K>
        where J : BaseRequest
        where K : BaseRequest
    {
        public Task<S> ListAsync(int take, int skip, string? search);

        public Task<S> GetByIdAsync(Guid id);

        public Task<S> CreateAsync(J entity);

        public Task<S> UpdateAsync(Guid id, K entity);

        public Task<S> DeleteAsync(Guid id);

    }
}
