using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Mapping.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class CartConfiguration : BaseEntityTypeConfiguration<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        base.Configure(builder);

        builder.Property(x => x.Number).UseIdentityColumn();// Auto generate number      
        builder.Property(x => x.Branch).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Date).IsRequired();      

        builder.HasMany(x => x.CartItems)
         .WithOne(y => y.Cart)
         .HasForeignKey(y => y.CartId);
    }
}
