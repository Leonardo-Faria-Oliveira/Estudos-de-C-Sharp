using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDByBlazorTemplate.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostController(IPostService postService) : BaseController<PostRequest>
    {

        private readonly IPostService _postService = postService;

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(Guid id)
        {
           
            var result = await _postService.Delete(id);

            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);

        }

        [HttpGet]
        public override async Task<IActionResult> Get(int take, int skip, string? search)
        {
            var result = await _postService.Get(take, skip, search);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetById(Guid id)
        {
            var result = await _postService.GetById(id);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public override async Task<IActionResult> Patch(Guid id, [FromBody] PostRequest request)
        {
            var result = await _postService.Patch(id, request);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] PostRequest request)
        {
            var result = await _postService.Post(request);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

        
    }
}
