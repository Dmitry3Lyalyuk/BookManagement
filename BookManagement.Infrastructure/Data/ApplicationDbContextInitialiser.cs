using BookManagement.Domain.Entity;
using BookManagement.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public ApplicationDbContextInitialiser(ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
                foreach (var roleName in Enum.GetNames(typeof(ApplicationRole)))
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = roleName });
                    }
                }

                var adminEmail = "admin@test.com";
                var adminUser = await _userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    adminUser = new User()
                    {
                        UserName = "admin",
                        Email = adminEmail,
                        FirstName = "Administrator",
                        LastName = "User"
                    };

                    var result = await _userManager.CreateAsync(adminUser, "Admin123!");

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(adminUser, ApplicationRole.Admin.ToString());
                    }
                }

                if (!_context.User.Any())
                {
                    var adminId = new Guid();
                    _context.User.AddRange(new Domain.Entity.User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "Aloxa",
                        Email = "Dmitry@test.com",
                        FirstName = "Dmitry",
                        LastName = "Lyalyuk",
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
