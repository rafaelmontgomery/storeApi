namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductResponse
{

    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The product description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The product price
    /// </summary>
    public decimal Price { get; set; }
}
