using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class SaleItem : BaseEntity
{
    public Sale Sale { get; set; } = null!;
    public Guid SaleId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Product Product { get; set; } = null!;
    public Guid ProductId { get; set; }
    public decimal TotalAmount => UnitPrice * Quantity;
    public decimal Discount => GetDiscount();
    public bool IsCancelled { get; set; }

    private decimal GetDiscount()
    {
        return Quantity switch
        {
            >= 4 and < 10 => TotalAmount * 0.1m,
            >= 10 and < 20 => TotalAmount * 0.2m,
            _ => TotalAmount,
        };
    }
}
