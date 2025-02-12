using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

public class ListCartRequest : PaginatedRequest
{
    /// <summary>
    /// Gets or sets the start date (Optional)
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date  (Optional)
    /// </summary>
    public DateTime? EndDate { get; set; }
}
