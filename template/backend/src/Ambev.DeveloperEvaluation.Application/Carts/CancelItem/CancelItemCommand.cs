using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelItem;
public class CancelItemCommand : IRequest<bool>
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
