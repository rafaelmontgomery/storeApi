using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Carts.TestData;
public static class CreateCartHandlerTestData
{
    private static readonly Faker<CreateCartCommand> createCartHandlerFaker = new Faker<CreateCartCommand>()
        .RuleFor(c => c.Branch, f => f.Commerce.Locale)
        .RuleFor(c => c.UserId, _ => Guid.NewGuid())
        .RuleFor(c => c.Date, _ => DateTime.UtcNow)
        .RuleFor(c => c.CartItems, f => cartItemFaker!.Generate(f.Random.Int(1, 10)));


    private static readonly Faker<CartItemCommand> cartItemFaker = new Faker<CartItemCommand>()
        .RuleFor(i => i.ProductId, f => Guid.NewGuid())
        .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20));

    public static CreateCartCommand GenerateValidCommand()
    {
        return createCartHandlerFaker.Generate();
    }
}
