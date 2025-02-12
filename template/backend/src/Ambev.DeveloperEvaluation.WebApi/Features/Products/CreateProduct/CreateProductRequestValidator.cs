using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for user creation command.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:  
    /// - Title: Required, length between 3 and 50 characters
    /// - Description: Required, length between 10 and 500 characters
    /// - Price: Required, length between 0,1 and 99999999,99
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Description).NotEmpty().Length(10, 500);
        RuleFor(product => product.Price).InclusiveBetween(0.1m, 99999999.99m);
    }
}
