using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CancelItem;

public class CancelItemRequestValidator : AbstractValidator<CancelItemRequest>
{
    /// <summary>
    /// Initializes validation rules for CancelItemRequest
    /// </summary>
    public CancelItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");

        RuleFor(x => x.ItemId)
           .NotEmpty()
           .WithMessage("Cart item ID is required");
    }
}
