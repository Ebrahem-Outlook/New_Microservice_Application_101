using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.API.Models;

namespace User.API.Database;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Users> Users { get; set; }
    public DbSet<UserCreatedEvent> UserCreatedEvents { get; set; }

    public DbSet<ProductCreatedEvent> ProductCreatedEvents { get; set; }

    public DbSet<OrderCreatedEvent> OrderCreatedEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
