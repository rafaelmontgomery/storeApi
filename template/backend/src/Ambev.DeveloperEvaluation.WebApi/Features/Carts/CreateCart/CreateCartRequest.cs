namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    /// <summary>
    /// Gets or sets the date and time when the cart was made.  
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the customer id who made a purchase.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the branch where the cart was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cart's items and products
    /// </summary>
    public IEnumerable<CartItemRequest> CartItems { get; set; } = [];
}
