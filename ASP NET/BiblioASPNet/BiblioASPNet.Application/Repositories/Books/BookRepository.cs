using BiblioASPNet.Application.Data.Context;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Utils;
using Microsoft.EntityFrameworkCore;

namespace BiblioASPNet.Application.Repositories.Books
{
    public class BookRepository(AppDbContext _context) : BaseRepository<Book>(_context), IBookRepository
    {
        public override async Task<Pagination<Book>> ListAsync(int skip, int take, string search)
        {
            var query = _context.Set<Book>().AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(t => t.Title.Contains(search));
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {

                query = query.Take(take);

            }

            int total = await query.CountAsync();

            ICollection<Book> result = await query.ToListAsync();

            var pagination = new Pagination<Book>
            {
                Skip = skip,
                Take = take,
                Total = total,
                Content = result
            };

            return await Task.FromResult(pagination);
        }
    }
}
