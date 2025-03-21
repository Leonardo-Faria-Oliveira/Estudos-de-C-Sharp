using BiblioASPNet.Application.Data.Context;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Utils;
using Microsoft.EntityFrameworkCore;

namespace BiblioASPNet.Application.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {

        protected private readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            _context.SaveChanges();

            return await Task.FromResult(entity);
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return await Task.FromResult(true);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {

            var result = await _context.Set<T>().AsQueryable().FirstAsync(t => t.Id == id);

            return await Task.FromResult(result);

        }

        public virtual async Task<Pagination<T>> ListAsync(int skip, int take, string search)
        {
            var query = _context.Set<T>().AsQueryable();

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {

                query = query.Take(take);

            }

            int total = await query.CountAsync();

            ICollection<T> result = await query.ToListAsync();

            var pagination = new Pagination<T>
            {
                Skip = skip,
                Take = take,
                Total = total,
                Content = result
            };

            return await Task.FromResult(pagination);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();

            return await Task.FromResult(entity);

        }


    }
}
