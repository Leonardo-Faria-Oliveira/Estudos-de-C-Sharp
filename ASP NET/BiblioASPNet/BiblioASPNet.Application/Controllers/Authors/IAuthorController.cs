using BiblioASPNet.Application.Controllers;
using BiblioASPNet.Application.Requests.Authors;

namespace BiblioASPNet.Application.Controllers.Authors
{
    public interface IAuthorController : IController<CreateAuthorRequest, UpdateAuthorRequest>;

}
