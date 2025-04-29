using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Seed>>();

            try
            {
                await context.Database.MigrateAsync();
                
                // We don't need to add data here since we're using HasData in OnModelCreating
                // This method is just to ensure the database is created and migrations are applied
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during migration");
            }
        }
}
