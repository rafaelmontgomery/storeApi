using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Product : BaseEntity
{
    /// <summary>
    /// Gets the product title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product image
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product rating
    /// </summary>
    public Rating Rating { get; set; } = null!;

    /// <summary>
    /// Reference to cart items
    /// </summary>
    public ICollection<CartItem> CartItems { get; } = [];

    /// <summary>
    /// Initializes a new instance of the Product class.
    /// </summary>
    public Product() { }
}
