using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async Task InitialDbAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialAsync();
            await initialiser.SeedAsync();
        }
    }
}
