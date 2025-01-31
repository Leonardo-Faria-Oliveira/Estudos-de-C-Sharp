using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Utils;
using Microsoft.EntityFrameworkCore;

namespace CRUDByBlazorTemplate.Repositories
{
    public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
    {
        public Task<Pagination<User>> Get(int take, int skip, string? search)
        {

            var query = context.Users.AsQueryable();
            query.Include(u => u.Id)
                .Include(u => u.Username)
                .Include(u => u.Email)
                .Include(u => u.Role)
                .Include(u => u.Avatar);

            return base.Get(take, skip, search, query);

        }

        public Task<User> GetById(Guid Id)
        {
            return base.GetById(Id, [
                u => u.Id,
                u => u.Username,
                u => u.FullName,
                u => u.Email,
                u => u.Role,
                u => u.Avatar,
            ]);
        }
    }
}
