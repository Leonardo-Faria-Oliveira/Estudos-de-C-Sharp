using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioASPNet.Application.Controllers.Books
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : 
        BaseController<CreateBookRequest, UpdateBookRequest>,
        IBookController
    {

        public BookController(IService<CreateBookRequest, UpdateBookRequest> _service) : base(_service)
        {
            
        }
    }
}
