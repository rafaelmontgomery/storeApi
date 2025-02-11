using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Mapping.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class ProductConfiguration : BaseEntityTypeConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        base.Configure(builder);

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).IsRequired().HasMaxLength(500);
        builder.Property(u => u.Price).IsRequired().HasPrecision(10, 2); //10000000,00

        builder.HasMany(x => x.SaleItems)
           .WithOne(y => y.Product)
           .HasForeignKey(y => y.ProductId);
    }
}
