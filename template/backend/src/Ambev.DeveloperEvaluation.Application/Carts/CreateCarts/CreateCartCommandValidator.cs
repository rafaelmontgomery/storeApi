using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.Date).Must(date => date >= DateTime.Now);
        RuleFor(cart => cart.UserId).NotEmpty();
        RuleFor(cart => cart.Branch).NotEmpty();
        RuleForEach(cart => cart.CartItems).SetValidator(new CartItemCommandValidator());
    }
}
