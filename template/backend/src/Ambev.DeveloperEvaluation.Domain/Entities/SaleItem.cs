using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents items of the sale
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the sale reference
    /// </summary>
    public Sale Sale { get; set; } = null!;

    /// <summary>
    /// Gets the sale id
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the quantity sold of the item
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the unit price of the product
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the product information
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// Gets the product id
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the total amount per item without discount
    /// </summary>
    public decimal TotalAmount => UnitPrice * Quantity;

    /// <summary>
    /// Gets the discount per item
    /// </summary>
    public decimal Discount => GetDiscount();

    /// <summary>
    /// Gets the item status (Cancelled/Not Cancelled)
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Calculates discount based on business rule
    /// </summary>
    private decimal GetDiscount()
    {
        return Quantity switch
        {
            >= 4 and < 10 => TotalAmount * 0.1m,
            >= 10 and < 20 => TotalAmount * 0.2m,
            _ => TotalAmount,
        };
    }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem() { }
}
