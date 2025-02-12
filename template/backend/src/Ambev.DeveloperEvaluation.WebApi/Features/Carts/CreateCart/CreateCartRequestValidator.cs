using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(cart => cart.Date).Must(date => date >= DateTime.Now);
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Branch).NotEmpty();
        RuleForEach(cart => cart.CartItems).SetValidator(new CartItemRequestValidator());
    }
}