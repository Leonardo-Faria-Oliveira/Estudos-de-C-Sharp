using Application.UseCases.User.Commands;
using Application.UseCases.User.ViewModels;
using Domain.Adapters.Responses;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {

        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<UserInfoViewModel>> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send<BaseResponse<UserInfoViewModel>>(command, cancellationToken);
            return Ok(result);
        }
    }
}
