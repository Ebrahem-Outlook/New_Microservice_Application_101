using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.API.Models;

namespace User.API.Database.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName);

        builder.HasKey(x => x.LastName);

        builder.HasKey(x => x.Email);

        builder.HasKey(x => x.Password);
    }
}
