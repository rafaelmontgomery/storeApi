using Ambev.DeveloperEvaluation.Application.Carts.CancelItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CancelItem;

public class CancelItemProfile : Profile
{
    public CancelItemProfile()
    {
        CreateMap<CancelItemRequest, CancelItemCommand>();
    }
}
