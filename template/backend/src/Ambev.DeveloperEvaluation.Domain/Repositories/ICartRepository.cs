using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Cart and Cart Item entity operations
/// </summary>
public interface ICartRepository
{
    /// <summary>
    /// Creates a new cart in the repository
    /// </summary>
    /// <param name="cart">The cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart</returns>
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);


    /// <summary>
    /// Get query with optional date filter
    /// </summary>
    /// <param name="startDate">Optional start date</param>
    /// <param name="endDate">Optional end date</param>
    /// <returns></returns>
    IQueryable<Cart> GetPaginatedCarts(DateTime? startDate, DateTime? endDate);



    /// <summary>
    /// Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart if found, null otherwise</returns>
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancel a item on database
    /// </summary>
    /// <param name="item">Item to be cancelled</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<bool> CancelItemAsync(CartItem item, CancellationToken cancellationToken = default);
}
