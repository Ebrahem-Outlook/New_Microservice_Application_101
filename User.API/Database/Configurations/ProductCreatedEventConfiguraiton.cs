using Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace User.API.Database.Configurations;

public class ProductCreatedEventConfiguraiton : IEntityTypeConfiguration<ProductCreatedEvent>
{
    public void Configure(EntityTypeBuilder<ProductCreatedEvent> builder)
    {
        builder.HasKey(x => x.EventId);
        builder.Property(x => x.ProductId);
        builder.Property(x => x.CreatedOnUtc);
    }
}
