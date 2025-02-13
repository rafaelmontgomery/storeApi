using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Carts.TestData;
using AutoMapper;
using Bogus;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Carts;

[Trait("Category", "Carts")]
public class CreateCartHandlerTests
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly CreateCartHandler _handler;


    public CreateCartHandlerTests()
    {
        _cartRepository = Substitute.For<ICartRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _mediator = Substitute.For<IMediator>();
        _handler = new CreateCartHandler(_cartRepository, _productRepository, _mapper, _mediator);
    }

    /// <summary>
    /// Tests that a valid cart creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid cart data When creating user Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateCartHandlerTestData.GenerateValidCommand();

        var faker = new Faker();

        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            Branch = command.Branch,
            Date = command.Date,
            UserId = command.UserId,
            CartItems = command.CartItems.Select(i => new CartItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = Math.Round(faker.Random.Decimal(0.1m, 99999.99m), 2)
            })
            .ToList()
        };

        var products = cart.CartItems.Select(i => new Product { Id = i.ProductId, Price = i.UnitPrice });

        var result = new CreateCartResult
        {
            Id = cart.Id,
        };


        _mapper.Map<Cart>(command).Returns(cart);
        _mapper.Map<CreateCartResult>(cart).Returns(result);

        _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>()).Returns(cart);
        _productRepository.GetByIdsAsync(Arg.Any<IEnumerable<Guid>>(), Arg.Any<CancellationToken>()).Returns(products);

        // When
        var createCartResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createCartResult.Should().NotBeNull();
        createCartResult.Id.Should().Be(cart.Id);
        await _cartRepository.Received(1).CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid cart creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid user data When creating user Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateCartCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }
}
