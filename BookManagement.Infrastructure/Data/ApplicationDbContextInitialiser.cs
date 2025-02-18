using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        public ApplicationDbContextInitialiser(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitialAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex) { }
        }

        public async Task SeedAsync()
        {
            try
            {
                if (_context.User.Any())
                {
                    var adminId = new Guid();
                    _context.User.AddRange(new Domain.Entity.User
                    {
                        Id = adminId,
                        UserName = "admin",
                        Email = "admin@test.com",
                        FirstName = "Admin",
                        LastName = "User",
                        CreatedBy = null,
                        CreatedAt = DateTime.Now,
                        LastModifiedBy = null,
                        LastModifiedAt = DateTime.Now
                    });
                }

                if (_context.Books.Any())
                {
                    _context.Books.AddRange(
                        new Domain.Entity.Book()
                        {
                            Id = Guid.NewGuid(),
                            title = "SilverSpoon",
                            publicationYear = 1990,
                            authorName = "AlexVan",
                            viewCount = 1,
                            CreatedBy = null,
                            CreatedAt = DateTime.Now,
                            LastModifiedBy = null,
                            LastModifiedAt = DateTime.Now
                        },
                        new Domain.Entity.Book()
                        {
                            Id = Guid.NewGuid(),
                            title = "BlackRock",
                            publicationYear = 1989,
                            authorName = "Alex2",
                            viewCount = 2,
                            CreatedBy = null,
                            CreatedAt = DateTime.Now,
                            LastModifiedBy = null,
                            LastModifiedAt = DateTime.Now
                        });
                }
            }
            catch
            {

            }
        }

    }
}
