using CRUDByBlazorTemplate.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRUDByBlazorTemplate.Controllers
{
    public abstract class BaseController<R> : ControllerBase where R : BaseRequest
    {

        public BaseController() { }

        protected IActionResult ErrorHttpResponse(HttpStatusCode code, object? response = null)
        {
            switch (code)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                default:
                    return StatusCode((int)code, response);
            }
        }

        public abstract Task<IActionResult> Get(int take, int skip, string? search);

        public abstract Task<IActionResult> GetById(Guid id);

        public abstract Task<IActionResult> Post([FromBody] R request);

        public abstract Task<IActionResult> Patch(Guid id, [FromBody] R request);

        public abstract Task<IActionResult> Delete(Guid id);

    }
}
