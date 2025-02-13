using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartResponse
{
    /// <summary>
    /// The unique identifier of the created cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The number of the cart. 
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// The date and time when the cart was made.  
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The customer who made a purchase.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// The customer id who made a purchase.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The total cart amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The branch where the cart was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The cart's items and products
    /// </summary>
    public IEnumerable<CartItemResponse> CartItems { get; set; } = [];

    /// <summary>
    /// The cart's total discount
    /// </summary>
    public decimal TotalDiscount { get; set; }
}
