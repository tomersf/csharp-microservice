
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext? context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Platforms.AddRange(
                    new Platform() { Name = "Kubernetes", Publisher = "GCP", Cost = "Cloud" },
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker", Cost = "Free" },
                    new Platform() { Name = "Azure", Publisher = "Microsoft", Cost = "Paid" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}