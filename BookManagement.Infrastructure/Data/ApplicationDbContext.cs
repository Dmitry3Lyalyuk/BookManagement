using BookManagement.Application.Common;
using BookManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IAppicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
