using BiblioASPNet.Application.Requests;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace BiblioASPNet.Application.Controllers
{

    public abstract class BaseController<J, K> : ControllerBase, IController<J, K>
        where J : BaseRequest
        where K : BaseRequest
    {

        private readonly IService<J, K> _service;

        protected BaseController(IService<J, K> service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> Get(int take, int skip, string? search)
        {
            return Ok(await _service.ListAsync(take, skip, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _service.GetByIdAsync(id);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] K request)
        {
            var result = await _service.UpdateAsync(id, request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] J request)
        {
            var result = await _service.CreateAsync(request);

            return Created(string.Empty, result);
        }


    }
}
