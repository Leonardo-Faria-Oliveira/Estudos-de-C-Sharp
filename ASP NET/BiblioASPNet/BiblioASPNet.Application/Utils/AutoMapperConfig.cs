using AutoMapper;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Requests.Authors;

namespace BiblioASPNet.Application.Utils
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {

            CreateMap<CreateAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();

        }
    }
}
