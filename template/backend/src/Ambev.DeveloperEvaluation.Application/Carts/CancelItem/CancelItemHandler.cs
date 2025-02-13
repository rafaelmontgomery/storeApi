using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Carts.CancelItem;
public class CancelItemHandler : IRequestHandler<CancelItemCommand, bool>
{
    //TODO: Publish a notification ItemCancelled
    private readonly IMediator _mediator;
    private readonly ICartRepository _cartRepository;
    private readonly IDistributedCache _cache;

    public CancelItemHandler(IMediator mediator, ICartRepository cartRepository, IDistributedCache cache)
    {
        _mediator = mediator;
        _cartRepository = cartRepository;
        _cache = cache;
    }

    public async Task<bool> Handle(CancelItemCommand request, CancellationToken cancellationToken)
    {
        Cart cart = null!;
        string cacheKey = $"cart:{request.Id}";
        bool useCache = true;

        var cartCache = useCache ? await _cache.GetStringAsync(cacheKey, cancellationToken) : string.Empty;

        if (string.IsNullOrEmpty(cartCache))
            cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new InvalidOperationException($"Cart id {request.Id} is invalid.");
        else
            cart = JsonConvert.DeserializeObject<Cart>(cartCache) ??
                throw new InvalidOperationException($"Invalid cache from key {cacheKey}.");

        var item = cart!.CartItems.FirstOrDefault(i => i.Id == request.ItemId) ??
            throw new InvalidOperationException($"Item id {request.ItemId} is invalid.");

        if (!await _cartRepository.CancelItemAsync(item, cancellationToken))
        {
            return false;
        }

        if (useCache)
        {
            cartCache = JsonConvert.SerializeObject(cart, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            await _cache.SetStringAsync(cacheKey, cartCache, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) }, cancellationToken);
        }

        return true;
    }
}
