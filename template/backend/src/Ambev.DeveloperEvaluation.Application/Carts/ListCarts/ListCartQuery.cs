using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
public class ListCartQuery : IRequest<IQueryable<Cart>>
{
    /// <summary>
    /// Gets or sets the start date (Optional)
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date (Optional)
    /// </summary>
    public DateTime? EndDate { get; set; }

}
