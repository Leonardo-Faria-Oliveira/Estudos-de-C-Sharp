using AutoMapper;
using BiblioASPNet.Application.Exceptions;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Responses.Dtos.Authors;
using BiblioASPNet.Application.Services.Authors;
using BiblioASPNet.Application.Utils;
using System.Net;
using TestUtils.Mapper;
using TestUtils.Repository;
using TestUtils.Request.Authors;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Unit.Test.Services.Authors
{
    public class AuthorServiceTest
    {


        private List<Author> authorList;
        

        private void GetAuthors()
        {
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build();
            var author_1 = mapper.Map<Author>(request);
            var request_2 = CreateAuthorRequestBuilder.Build();
            var author_2 = mapper.Map<Author>(request_2);
            var request_3 = CreateAuthorRequestBuilder.Build();
            var author_3 = mapper.Map<Author>(request_3);

            authorList = new List<Author>
            {
                author_1,
                author_2,
                author_3,
            };
        }

        public AuthorServiceTest()
        {
            GetAuthors();
        }


        [Fact]
        public async Task ShouldBePossibleToCreateAnAuthor()
        {

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build();
            
            //Act
            var result = await service.CreateAsync(request);
            var author = mapper.Map<ShortAuthorDto>(result.Content);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(["Sucesso, cadastrado com sucesso!"], result.Message);
            Assert.Equal(request.Name, author.Name);


        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldNotBePossibleToCreateAnAuthorWithoutAName(string name)
        {

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build("name", name);
            
            //Assert
            var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => service.CreateAsync(request));
            Assert.Equal("O campo Name não pode ser nulo ou vazio.", exception.GetErrors().First());

        }

        [Fact]
        public async Task ShouldNotBePossibleToCreateAnAuthorWithANameWithLessThan3Caracthers()
        {

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build("name", "12");

            //Assert
            var exception = await Assert.ThrowsAsync<ValidationErrorException>(() => service.CreateAsync(request));
            Assert.Equal("O campo Name não pode possuir menos de 3 caracteres.", exception.GetErrors().First());

        }


        [Fact]
        public async Task ShouldBePossibleToListAuthorsWithoutParams()
        {

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();

            var result = await service.ListAsync(0, 0, null);
            var paginationObj = result.Content;
            var type = paginationObj.GetType();

            int skip = (int)type.GetProperty("Skip").GetValue(paginationObj);
            int take = (int)type.GetProperty("Take").GetValue(paginationObj);
            int total = (int)type.GetProperty("Total").GetValue(paginationObj);
            var content = type.GetProperty("Content").GetValue(paginationObj);

            var authors = authorList.Select(author => mapper.Map<ShortAuthorDto>(author)).ToList();

            Assert.Equal(0, skip);
            Assert.Equal(0, take);
            Assert.Equal(authors.Count, total);
            Assert.Equal(authors, content);
        }


        [Theory]
        [InlineData(2, 0, "")]
        [InlineData(1, 2, "")]
        [InlineData(0, 0, "Teste")]
        [InlineData(0, 0, "Mauricio")]
        public async Task ShouldReturnAuthorsBasedOnParams(int take, int skip, string search)
        {
            authorList[0] = new Author
            {
                Name = "Teste",
            };

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();

            var result = await service.ListAsync(take, skip, search);
            var paginationObj = result.Content;
            var type = paginationObj.GetType();
            var content = type.GetProperty("Content").GetValue(paginationObj);

            var authors = authorList.Select(author => mapper.Map<ShortAuthorDto>(author)).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                authors = authors.Where(t => t.Name.Contains(search)).ToList();
            }

            if (skip > 0)
            {
                authors = authors.Skip(skip).ToList();
            }
            if (take > 0)
            {

                authors = authors.Take(take).ToList();

            }

            Assert.Equal(authors, content);
        }

        [Fact]
        public async Task ShouldReturnAnAuthorById()
        {
            var uid = Guid.NewGuid();
            authorList[0] = new Author
            {
                Id = uid,
            };

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();

            var response = await service.GetByIdAsync(uid);

            var detailedAuthor = mapper.Map<AuthorDetailsDto>(authorList[0]);

            Assert.Equal(detailedAuthor, response.Content);

        }

        [Theory]
        [InlineData("a7a1cc3c-fc68-4374-9f8d-62e8de677029")]
        public async Task ShouldNotBeAbleToReturnAnAuthorWithAInvalidId(string stringUid)
        {
            var uid = Guid.Parse(stringUid);

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();

            var response = await service.GetByIdAsync(uid);

            Assert.Null(response.Content);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("Erro, não encontrado", response.Message!.First());

        }

        private AuthorService GetAuthorService()
        {
            var mapper = AutoMapperBuilder.Build();

            var authorRepository = new AuthorRepositoryBuilder()
            .WithCreateAsync(authorList.First())
            .WithListAsync(authorList)
            .WithGetByIdAsync(authorList)
            .Build();

            return new AuthorService(authorRepository, mapper);
        }
    }
}
