using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.API.Models;

namespace Product.API.Database.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name).IsRequired();

        builder.Property(product => product.Price).IsRequired();

        builder.Property(product => product.CreatedOn).IsRequired();

        builder.Property(product => product.Stock).IsRequired();
    }
}
