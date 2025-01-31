
using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Repository;
using CRUDByBlazorTemplate.Utils;
using Microsoft.EntityFrameworkCore;

namespace CRUDByBlazorTemplate.Repositories
{
    public class PostRepository(AppDbContext context) : Repository<Post>(context), IPostRepository
    {
       
        public Task<Pagination<Post>> Get(int take, int skip, string? search)
        {

            var query = context.Posts.AsQueryable();
            query.Include(p => p.Id)
                .Include(p => p.Title)
                .Include(p => p.Content)
                .Include(p => p.PublishDateTime)
                .Include(p => p.Category)
                .Include(p => p.User);

            return base.Get(take, skip, search, query);    

        }

        public Task<Post> GetById(Guid Id)
        {
            
            return base.GetById(Id, [
                p => p.Id,
                p => p.Title,
                p => p.Content,
                p => p.PublishDateTime,
                p => p.Category,
                p => p.User
            ]);    

        }

    }
}
