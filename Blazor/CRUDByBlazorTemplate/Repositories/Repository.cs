using CRUDByBlazorTemplate.Data.Context;
using CRUDByBlazorTemplate.Models;
using CRUDByBlazorTemplate.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDByBlazorTemplate.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        
        private readonly AppDbContext _context;

        public Repository(AppDbContext context) 
        {
        
            this._context = context;

        }

        public virtual async Task<Boolean> Delete(T entity)
        {
           
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return await Task.FromResult(true);
            
        }

        public virtual Task<Pagination<T>> Get(int take, int skip, string? search, IQueryable<T>? customQuery)
        {

            var query = _context.Set<T>().AsQueryable();

            var count = query.AsNoTracking().Count();

            if (customQuery != null)
            {
                query = customQuery;
            }
            
            if(skip > 0)
            {
                query = query.Skip(skip);
            }

            if(take > 0)
            {
                query = query.Take(take);
            }

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.ToString().Contains(search));
            }

            var pagination = new Pagination<T>
            {
                Skip = skip,
                Take = take,
                Total = count,
                Content = query.ToList()
            };

            return Task.FromResult(pagination);
        }

        public virtual async Task<T> GetById(Guid Id, Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            query.Include(T => includes);

            var entity = await query.FirstAsync(x => x.Id == Id);

            return entity;
        }

        public virtual Task<T> Patch(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();

            return Task.FromResult(entity);
        }

        public virtual async Task<T> Post(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();


           return await Task.FromResult(entity);
        }
    }
}
