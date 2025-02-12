using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.Events.CartCreated;
public class CartCreatedEventHandler : INotificationHandler<CartCreatedEvent>
{
    public Task Handle(CartCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Cart received: {notification.Cart.Id}");
        return Task.CompletedTask;
    }
}