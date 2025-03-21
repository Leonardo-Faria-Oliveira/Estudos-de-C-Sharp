using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Repositories.Authors;
using Moq;

namespace TestUtils.Repository
{
    public class AuthorRepositoryBuilder
    {

        private readonly Mock<IAuthorRepository> _repository;

        public AuthorRepositoryBuilder()
        {
            _repository = new Mock<IAuthorRepository>();
        }

        public AuthorRepositoryBuilder WithCreateAsync(Author entity)
        {
            _repository
                .Setup(repo => repo.CreateAsync(It.IsAny<Author>()))
                .ReturnsAsync(entity);
            return this;
        }

        public IAuthorRepository Build()
        {
            return _repository.Object;
        }

    }
}
