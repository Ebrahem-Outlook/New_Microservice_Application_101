using Microsoft.EntityFrameworkCore;
using User.API.Database;

namespace User.API.Extentions;

public static class MigrationExtentions
{
    public static void ApplyMigrations(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}
