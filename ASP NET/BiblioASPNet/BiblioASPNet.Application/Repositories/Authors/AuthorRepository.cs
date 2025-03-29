using BiblioASPNet.Application.Data.Context;
using BiblioASPNet.Application.Models;
using BiblioASPNet.Application.Utils;
using Microsoft.EntityFrameworkCore;

namespace BiblioASPNet.Application.Repositories.Authors
{
    public class AuthorRepository(AppDbContext _context) : BaseRepository<Author>(_context), IAuthorRepository
    {


        public override async Task<Pagination<Author>> ListAsync(int take, int skip, string search)
        {
            var query = _context.Set<Author>().AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(t => t.Name.Contains(search));
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

            ICollection<Author> result = await query.ToListAsync();

            var pagination = new Pagination<Author>
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
