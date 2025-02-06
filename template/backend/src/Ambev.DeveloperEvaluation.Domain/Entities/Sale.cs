using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents the sale with store items
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the number of the sale.
    /// Must not be null and will be generated automatically
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was made.  
    /// </summary>
    public DateTime SoldAt { get; set; }

    /// <summary>
    /// Gets the customer who made a purchase.
    /// </summary>
    public User Customer { get; set; } = null!;

    /// <summary>
    /// Gets the customer id who made a purchase.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the total sale amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets the sale's items and products
    /// </summary>
    public IEnumerable<SaleItem> SaleItems { get; set; } = [];

    /// <summary>
    /// Gets the sale's total discount
    /// </summary>
    public decimal TotalDiscount => SaleItems.Sum(item => item.Discount);

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        SoldAt = DateTime.UtcNow;
    }
}