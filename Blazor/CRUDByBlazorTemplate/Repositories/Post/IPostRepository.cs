using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<Pagination<Post>> Get(int take, int skip, string? search);

        public Task<Post> GetById(Guid Id);

    }
}
