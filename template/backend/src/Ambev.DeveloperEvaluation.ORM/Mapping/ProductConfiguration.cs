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

        builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasPrecision(10, 2); //10000000,00
        builder.Property(p => p.Category).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Image).IsRequired().HasMaxLength(50);

        builder.ComplexProperty(p => p.Rating, ratingBuilder =>
        {
            ratingBuilder.Property(r => r.Rate).IsRequired().HasColumnName("Rate").HasPrecision(6, 2);
            ratingBuilder.Property(r => r.Count).IsRequired().HasColumnName("RateCount").HasMaxLength(10);
        });

        builder.HasMany(x => x.CartItems)
           .WithOne(y => y.Product)
           .HasForeignKey(y => y.ProductId);
    }
}
