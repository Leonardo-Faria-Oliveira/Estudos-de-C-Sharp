using BiblioASPNet.Application.Exceptions;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Services.Authors;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestUtils.Mapper;
using TestUtils.Repository;
using TestUtils.Request.Authors;

namespace Unit.Test.Services.Authors
{
    public class AuthorServiceTest
    {

        [Fact]
        public async Task ShouldBePossibleToCreateAnAuthor()
        {

            //Arrange
            var service = GetAuthorService();
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build();
            
            //Act
            var result = await service.CreateAsync(request);
            var author = mapper.Map<Author>(result.Content);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Sucesso, cadastrado com sucesso!", result.Message);
            Assert.Equal(request.Name, author.Name);
            Assert.Equal(request.About, author.About);


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


        private static AuthorService GetAuthorService()
        {
            var mapper = AutoMapperBuilder.Build();
            var request = CreateAuthorRequestBuilder.Build();
            var entity = mapper.Map<Author>(request);
            var authorRepository = new AuthorRepositoryBuilder()
             .WithCreateAsync(entity)
            .Build();

            return new AuthorService(authorRepository, mapper);
        }
    }
}
