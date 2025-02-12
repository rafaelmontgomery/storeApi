using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CartItemRequest, CartItemCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>();
    }
}
