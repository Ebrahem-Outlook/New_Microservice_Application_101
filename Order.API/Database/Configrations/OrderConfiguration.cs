using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.API.Models;

namespace Order.API.Database.Configrations
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(order => order.Id);

            builder.Property(order => order.TotalPrice);
            
            builder.Property(order => order.CreatedOn);

            // Convert ProductIds (List<Guid>) to a comma-separated string for storage
            builder.Property(order => order.ProductIds)
                .HasConversion(
                    new ValueConverter<List<Guid>, string>(
                        v => string.Join(",", v.Select(g => g.ToString())), // Convert List<Guid> to comma-separated string
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(Guid.Parse) // Convert string back to List<Guid>
                              .ToList()
                    )
                );
        }
    }
}
