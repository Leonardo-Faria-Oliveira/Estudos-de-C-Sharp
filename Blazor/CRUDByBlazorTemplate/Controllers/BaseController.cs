using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRUDByBlazorTemplate.Controllers
{
    public class BaseController : ControllerBase
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

    }
}
