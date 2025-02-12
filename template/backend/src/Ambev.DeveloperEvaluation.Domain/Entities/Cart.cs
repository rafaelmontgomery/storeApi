using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents the cart with store items
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Cart : BaseEntity
{
    /// <summary>
    /// Gets the number of the cart.
    /// Must not be null and will be generated automatically
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// Gets the date and time when the cart was made.  
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the customer who made a purchase.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets the customer id who made a purchase.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets the total cart amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the branch where the cart was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets the cart's items and products
    /// </summary>
    public ICollection<CartItem> CartItems { get; set; } = [];

    /// <summary>
    /// Gets the cart's total discount
    /// </summary>
    public decimal TotalDiscount => CartItems.Sum(item => item.Discount);

    /// <summary>
    /// Initializes a new instance of the Cart class.
    /// </summary>
    public Cart()
    {       
    }
}