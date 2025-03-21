using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Responses;

namespace BiblioASPNet.Application.Services.Authors
{
    public interface IAuthorService : IService<ServiceResponse, CreateAuthorRequest, UpdateAuthorRequest>;
}
