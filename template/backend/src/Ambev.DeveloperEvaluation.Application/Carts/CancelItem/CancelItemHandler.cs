using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelItem;
public class CancelItemHandler : IRequestHandler<CancelItemCommand, bool>
{
    //TODO: Publish a notification ItemCancelled
    private readonly IMediator _mediator;
    private readonly ICartRepository _cartRepository;

    public CancelItemHandler(IMediator mediator, ICartRepository cartRepository)
    {
        _mediator = mediator;
        _cartRepository = cartRepository;
    }

    public async Task<bool> Handle(CancelItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken) ??
            throw new InvalidOperationException($"Cart id {request.Id} is invalid.");

        var item = cart.CartItems.FirstOrDefault(i => i.Id == request.ItemId) ??
            throw new InvalidOperationException($"Item id {request.ItemId} is invalid.");

        return await _cartRepository.CancelItemAsync(item, cancellationToken);
    }
}
