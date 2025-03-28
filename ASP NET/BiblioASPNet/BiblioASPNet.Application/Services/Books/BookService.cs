using AutoMapper;
using BiblioASPNet.Application.Exceptions;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Repositories;
using BiblioASPNet.Application.Repositories.Authors;
using BiblioASPNet.Application.Repositories.Books;
using BiblioASPNet.Application.Requests.Books;
using BiblioASPNet.Application.Responses;
using BiblioASPNet.Application.Responses.Dtos.Books;
using BiblioASPNet.Application.Utils.Validators;

namespace BiblioASPNet.Application.Services.Books
{
    public class BookService : BaseService<Book, CreateBookRequest, UpdateBookRequest, ShortBookDto, BookDetailsDto>, IBookService
    {

        private readonly IBookRepository _repository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper, IAuthorRepository authorRepository) : base(repository, mapper) 
        { 
            _repository = repository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public override async Task<ServiceResponse> CreateAsync(CreateBookRequest entity)
        {
            Validate(entity);

            var obj = _mapper.Map<Book>(entity);

            var author = await _authorRepository.GetByIdAsync(obj.AuthorId);

            if(author == null)
            {
                throw new AuthorNotFoundException(["Autor não existe"]);
            }

            obj.Author = author;

            await _repository.CreateAsync(obj);

            var book = _mapper.Map<ShortBookDto>(obj);

            return await Task.FromResult(
                new ServiceResponse(
                    System.Net.HttpStatusCode.OK,
                    ["Sucesso, cadastrado com sucesso!"],
                    book
                )
            );

        }
        

        private void Validate(CreateBookRequest entity)
        {
            var stringValidator = new StringValidator<CreateBookRequest>();
            var stringValidation = stringValidator.Validate(entity);

            if (!stringValidation.IsValid)
            {
                var errorMessages = stringValidation.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationErrorException(errorMessages);
            }
        }


    }
}
