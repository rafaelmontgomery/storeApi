using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Mapping.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class SaleConfiguration : BaseEntityTypeConfiguration<Sale>
{
    public override void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        base.Configure(builder);

        builder.Property(x => x.Number).UseIdentityColumn();// Auto generate number      
        builder.Property(x => x.Branch).IsRequired().HasMaxLength(100);
        builder.Property(x => x.SoldAt).IsRequired();
        builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(12, 2);

        builder.HasMany(x => x.SaleItems)
         .WithOne(y => y.Sale)
         .HasForeignKey(y => y.SaleId);
    }
}
