using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public class CartCreatedEvent : INotification
{
    public Cart Cart { get; set; }

    public CartCreatedEvent(Cart cart)
    {
        Cart = cart;
    }
}
