namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CartItemCommand
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
