using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CreateCartCommand : IRequest<CreateCartResult>
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
    /// Gets or sets the cart's items and products
    /// </summary>
    public IEnumerable<CartItemCommand> CartItems { get; set; } = [];
}

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
