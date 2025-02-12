using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CartItemCommandValidator : AbstractValidator<CartItemCommand>
{
    public CartItemCommandValidator()
    {
        RuleFor(item => item.Quantity).InclusiveBetween(0, 20);
        RuleFor(item => item.ProductId).NotEmpty();
    }
}
