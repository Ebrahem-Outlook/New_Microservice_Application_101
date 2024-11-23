using Microsoft.EntityFrameworkCore;
using Product.API.Database;

namespace Product.API.Extentions
{
    public static class MigrationExtentions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var scop = app.ApplicationServices.CreateScope();

            var dbContext = scop.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
