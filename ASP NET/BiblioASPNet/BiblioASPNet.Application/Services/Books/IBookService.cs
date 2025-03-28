using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Responses;

namespace BiblioASPNet.Application.Services.Books
{
    public interface IBookService : IService<CreateBookRequest, UpdateBookRequest>;
}
