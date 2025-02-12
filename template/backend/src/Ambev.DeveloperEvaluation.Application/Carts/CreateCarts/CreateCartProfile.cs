using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Cart>();
        CreateMap<CartItemCommand, CartItem>();
        CreateMap<Cart, CreateCartResult>();
    }
}
