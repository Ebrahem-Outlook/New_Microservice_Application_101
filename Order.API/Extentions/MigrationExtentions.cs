using Microsoft.EntityFrameworkCore;
using Order.API.Database;

namespace Order.API.Extentions;

public static class MigrationExtentions
{
    public static void ApplyMigrations(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}