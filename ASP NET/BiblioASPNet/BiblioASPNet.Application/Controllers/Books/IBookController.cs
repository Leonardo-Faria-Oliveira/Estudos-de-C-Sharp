using BiblioASPNet.Application.Requests.Books;

namespace BiblioASPNet.Application.Controllers.Books
{
    public interface IBookController : IController<CreateBookRequest, UpdateBookRequest>;
}
