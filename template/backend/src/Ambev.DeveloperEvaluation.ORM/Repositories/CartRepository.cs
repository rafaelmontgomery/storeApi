using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new cart in the database
    /// </summary>
    /// <param name="cart">The cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart</returns>
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }


    /// <summary>
    /// Get query with optional date filter
    /// </summary>
    /// <param name="startDate">Optional start date</param>
    /// <param name="endDate">Optional end date</param>
    /// <returns></returns>
    public IQueryable<Cart> GetPaginatedCarts(DateTime? startDate, DateTime? endDate)
    {
        var query = _context.Carts.AsQueryable();

        if (startDate.HasValue)
            query = query.Where(cart => cart.Date.ToUniversalTime() >= startDate.Value.ToUniversalTime());

        if (endDate.HasValue)
            query = query.Where(cart => cart.Date.ToUniversalTime() <= endDate.Value.ToUniversalTime());

        return query.Include(c => c.CartItems);
    }
}
