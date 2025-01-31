using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Utils;

namespace CRUDByBlazorTemplate.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

        public Task<Pagination<User>> Get(int take, int skip, string? search);

        public Task<User> GetById(Guid Id);

    }
}
