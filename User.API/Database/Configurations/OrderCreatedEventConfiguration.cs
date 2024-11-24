using Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace User.API.Database.Configurations
{
    public class OrderCreatedEventConfiguration : IEntityTypeConfiguration<OrderCreatedEvent>
    {
        public void Configure(EntityTypeBuilder<OrderCreatedEvent> builder)
        {
            builder.HasKey(x => x.EventId);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.CreatedOnUtc);
        }
    }
}
