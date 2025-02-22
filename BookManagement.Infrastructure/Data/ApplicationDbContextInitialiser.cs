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
                if (!_context.User.Any())
                {
                    var adminId = new Guid();
                    _context.User.AddRange(new Domain.Entity.User
                    {
                        Id = adminId,
                        UserName = "admin",
                        Email = "admin@test.com",
                        FirstName = "Admin",
                        LastName = "User",
                    });
                }

                if (!_context.Books.Any())
                {
                    _context.Books.AddRange(
                        new Domain.Entity.Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "SilverSpoon",
                            PublicationYear = 1990,
                            AuthorName = "AlexVan",
                            ViewCount = 1,
                        },
                        new Domain.Entity.Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "BlackRock",
                            PublicationYear = 1989,
                            AuthorName = "Alex2",
                            ViewCount = 2,
                        });
                }

                await _context.SaveChangesAsync();
            }
            catch
            {

            }
        }

    }
}
