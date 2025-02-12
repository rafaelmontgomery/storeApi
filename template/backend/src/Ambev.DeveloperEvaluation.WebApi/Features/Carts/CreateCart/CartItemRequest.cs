namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CartItemRequest
{
    /// <summary>
    /// Gets the product id
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity sold of the item
    /// </summary>
    public int Quantity { get; set; }
}
