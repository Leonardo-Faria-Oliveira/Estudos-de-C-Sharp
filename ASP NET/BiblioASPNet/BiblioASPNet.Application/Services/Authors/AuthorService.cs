using AutoMapper;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Repositories.Authors;
using BiblioASPNet.Application.Requests.Authors;
using BiblioASPNet.Application.Responses.Dtos.Authors;
using BiblioASPNet.Application.Services;
using BiblioASPNet.Application.Utils.Validators;
using FluentValidation;


namespace BiblioASPNet.Application.Services.Authors
{
    public class AuthorService :
        BaseService<Author, CreateAuthorRequest, UpdateAuthorRequest, ShortAuthorDto, AuthorDetailsDto>, IAuthorService
    {

        public AuthorService(IAuthorRepository _repository, IMapper _mapper) : base(_repository, _mapper)
        { }



    }

}
