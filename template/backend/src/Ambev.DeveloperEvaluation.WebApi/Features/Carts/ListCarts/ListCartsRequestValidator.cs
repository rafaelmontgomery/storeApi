using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

public class ListCartsRequestValidator : AbstractValidator<ListCartRequest>
{
    public ListCartsRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .NotEmpty()
            .WithMessage("PageNumber is required");

        RuleFor(x => x.PageSize)
            .NotEmpty()
            .WithMessage("PageSize is required");

    }
}
