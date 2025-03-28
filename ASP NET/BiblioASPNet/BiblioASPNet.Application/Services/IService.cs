using BiblioASPNet.Application.Requests;
using BiblioASPNet.Application.Responses;

namespace BiblioASPNet.Application.Services
{
    public interface IService<J, K>
        where J : BaseRequest
        where K : BaseRequest
    {
        public Task<ServiceResponse> ListAsync(int take, int skip, string? search);

        public Task<ServiceResponse> GetByIdAsync(Guid id);

        public Task<ServiceResponse> CreateAsync(J entity);

        public Task<ServiceResponse> UpdateAsync(Guid id, K entity);

        public Task<ServiceResponse> DeleteAsync(Guid id);

    }
}
