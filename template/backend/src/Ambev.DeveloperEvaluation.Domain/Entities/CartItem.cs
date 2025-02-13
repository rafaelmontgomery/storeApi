using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents items of the cart
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class CartItem : BaseEntity
{
    /// <summary>
    /// Gets the cart reference
    /// </summary>
    public Cart Cart { get; set; } = null!;

    /// <summary>
    /// Gets the cart id
    /// </summary>
    public Guid CartId { get; set; }

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
    /// Gets the total amount with discount per item
    /// </summary>
    public decimal TotalAmountWithDiscount => TotalAmount - Discount;

    /// <summary>
    /// Gets the item status (Cancelled/Not Cancelled)
    /// </summary>
    public bool IsCancelled { get; private set; }

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
    /// Cancel a item
    /// </summary>
    public void SetCancelled() => IsCancelled = true;

    /// <summary>
    /// Initializes a new instance of the CartItem class.
    /// </summary>
    public CartItem() { }
}
