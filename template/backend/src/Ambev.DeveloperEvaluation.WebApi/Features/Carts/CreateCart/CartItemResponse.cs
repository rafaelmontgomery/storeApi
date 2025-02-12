namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CartItemResponse
{
    /// <summary>
    /// The quantity sold of the item
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The product title
    /// </summary>
    public string ProductTitle { get; set; } = null!;

    /// <summary>
    /// Gets the product id
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The total amount per item without discount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The discount per item
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The item status (Cancelled/Not Cancelled)
    /// </summary>
    public bool IsCancelled { get; set; }
}