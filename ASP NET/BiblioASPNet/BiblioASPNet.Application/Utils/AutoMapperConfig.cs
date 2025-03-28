using AutoMapper;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Responses.Dtos.Authors;
using BiblioASPNet.Application.Responses.Dtos.Books;

namespace BiblioASPNet.Application.Utils
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {

            CreateMap<CreateAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();
            CreateMap<Author, ShortAuthorDto>();
            CreateMap<Author, AuthorDetailsDto>();

            CreateMap<CreateBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();
            CreateMap<Book, ShortBookDto>();
            CreateMap<Book, BookDetailsDto>();

        }
    }
}
