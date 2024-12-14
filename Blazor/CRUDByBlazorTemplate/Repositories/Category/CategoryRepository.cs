
using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Utils;
using Microsoft.EntityFrameworkCore;

namespace CRUDByBlazorTemplate.Repository
{
    public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
    {
        
        public Task<Category> GetById(Guid Id)
        {
            
            return base.GetById(Id, [
                c => c.Id,
                c => c.Title,
                c => c.Description,
            ]);     

        }

        public Task<Pagination<Category>> Get(int skip, int take, string? search)
        {

            var query = context.Categories.AsQueryable();
            query.Include(c => c.Id);
            query.Include(c => c.Title);
            query.Include(c => c.Description);

            return base.Get(skip, take, search, query);
        }

    }
}
