using BiblioASPNet.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BiblioASPNet.Application.Controllers
{
    public interface IController<J, K>
    where J : BaseRequest
    where K : BaseRequest
    {

        public Task<IActionResult> Get(int take, int skip, string? search);

        public Task<IActionResult> GetById(Guid id);

        public Task<IActionResult> Post([FromBody] J request);

        public Task<IActionResult> Patch(Guid id, [FromBody] K request);

        public Task<IActionResult> Delete(Guid id);
    }
}
