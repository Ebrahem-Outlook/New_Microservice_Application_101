using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.API.Database.Configurations;

public class UserCreatedEventConfiguration : IEntityTypeConfiguration<UserCreatedEvent>
{
    public void Configure(EntityTypeBuilder<UserCreatedEvent> builder)
    {
        builder.HasKey(x => x.EventId);

        builder.Property(x => x.EventId);

        builder.Property(x => x.CreatedOnUtc);
    }
}
