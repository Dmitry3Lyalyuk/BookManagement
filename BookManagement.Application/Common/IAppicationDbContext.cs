using BookManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Common
{
    public interface IAppicationDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

