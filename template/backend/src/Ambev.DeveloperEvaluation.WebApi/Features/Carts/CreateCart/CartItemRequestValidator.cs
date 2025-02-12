using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CartItemRequestValidator : AbstractValidator<CartItemRequest>
{
    public CartItemRequestValidator()
    {
        RuleFor(item => item.Quantity).InclusiveBetween(0, 20);
        RuleFor(item => item.ProductId).NotEmpty();
    }
}