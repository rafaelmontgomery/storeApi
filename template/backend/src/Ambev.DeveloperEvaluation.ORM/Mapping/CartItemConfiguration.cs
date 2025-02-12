using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Mapping.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class CartItemConfiguration : BaseEntityTypeConfiguration<CartItem>
{
    public override void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        base.Configure(builder);

        builder.Property(u => u.Quantity).IsRequired().HasMaxLength(2);
        builder.Property(u => u.IsCancelled).IsRequired();
        builder.Property(u => u.UnitPrice).IsRequired().HasPrecision(10, 2);
    }
}
