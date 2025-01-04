using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Utils;
using System.Linq.Expressions;

namespace CRUDByBlazorTemplate.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        public Task<Pagination<Category>> Get(int take, int skip, string? search);

        public Task<Category> GetById(Guid Id);

    }
}
