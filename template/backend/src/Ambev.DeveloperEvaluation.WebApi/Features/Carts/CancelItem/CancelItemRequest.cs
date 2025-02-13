namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CancelItem;

public class CancelItemRequest
{
    /// <summary>
    /// The unique identifier of the cart to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique identifier of the cart item to retrieve
    /// </summary>
    public Guid ItemId { get; set; }
}
