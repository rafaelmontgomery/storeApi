using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
public class ListCartHandler : IRequestHandler<ListCartQuery, IQueryable<Cart>>
{
    private readonly ICartRepository _cartRepository;

    public ListCartHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<IQueryable<Cart>> Handle(ListCartQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Cart> query = _cartRepository.GetPaginatedCarts(request.StartDate, request.EndDate);
        return await Task.FromResult(query);
    }
}
