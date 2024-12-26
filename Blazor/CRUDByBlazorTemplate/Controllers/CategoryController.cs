using CRUDByBlazorTemplate.Request;
using CRUDByBlazorTemplate.Services;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CRUDByBlazorTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : BaseController
    {

        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Get(int take, int skip, string? search)
        {
            var result = await _categoryService.Get(take, skip, search);

            if(result.StatusCode != HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.Post(request);

            if (result.StatusCode != HttpStatusCode.Created)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Created("", result);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] CategoryRequest request)
        {

            var result = await _categoryService.Patch(id, request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.Delete(id);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return ErrorHttpResponse(result.StatusCode, result);
            }

            return Ok(result);
        }

    }
}
