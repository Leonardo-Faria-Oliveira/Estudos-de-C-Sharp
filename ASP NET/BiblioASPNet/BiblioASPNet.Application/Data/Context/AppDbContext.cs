using BiblioASPNet.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BiblioASPNet.Application.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

    }
}
