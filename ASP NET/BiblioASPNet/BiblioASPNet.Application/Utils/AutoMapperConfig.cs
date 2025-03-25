using AutoMapper;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Requests.Books;

namespace BiblioASPNet.Application.Utils
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {

            CreateMap<CreateAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();

            CreateMap<CreateBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();

        }
    }
}
