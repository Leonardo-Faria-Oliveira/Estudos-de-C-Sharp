using Microsoft.AspNetCore.Mvc;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Services;

namespace BiblioASPNet.Application.Controllers.Authors
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : BaseController<CreateAuthorRequest, UpdateAuthorRequest>, IAuthorController
    {
        public AuthorController(IService<CreateAuthorRequest, UpdateAuthorRequest> service) : base(service)
        {
        }
    }
}
