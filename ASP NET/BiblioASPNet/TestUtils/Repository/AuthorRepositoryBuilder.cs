using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Repositories.Authors;
using BiblioASPNet.Application.Responses.Dtos.Books;
using BiblioASPNet.Application.Utils;
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

        public AuthorRepositoryBuilder WithListAsync(List<Author> authors)
        {

            _repository
                .Setup(repo => repo.ListAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string?>()))
                .Returns((int take, int skip, string? search) =>
                {
                    var filteredAuthors = string.IsNullOrEmpty(search)
                        ? authors
                        : authors.Where(a => a.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

                    if(skip > 0)
                    {
                        filteredAuthors = filteredAuthors.Skip(skip);
                    }

                    if(take > 0)
                    {
                        filteredAuthors = filteredAuthors.Take(take);
                    }

                    var paginatedAuthors = new Pagination<Author>
                    {
                        Content = filteredAuthors.ToList(),
                        Skip = skip,
                        Take = take,
                        Total = authors.Count
                    };

                    return Task.FromResult(paginatedAuthors);
                });
            return this;
        }

        
        public AuthorRepositoryBuilder WithGetByIdAsync(List<Author> authors)
        {
            _repository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .Returns((Guid id) =>
                {

                    var author = authors.Where(author => author.Id == id).FirstOrDefault();

                    return Task.FromResult(author);

                });
                
            return this;
        }


        public AuthorRepositoryBuilder WithUpdateAsync(Author author)
        {
            _repository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Author>()))
                .ReturnsAsync(author);

            return this;
        }

        public AuthorRepositoryBuilder WithDeleteAsync(List<Author> authors)
        {
            _repository
                .Setup(repo => repo.DeleteAsync(It.IsAny<Author>()))
                .Returns((Author author) =>
                {
            
                    authors.Remove(author);

                    return Task.FromResult(true);

                });

            return this;
        }

        public IAuthorRepository Build()
        {
            return _repository.Object;
        }

    }
}
