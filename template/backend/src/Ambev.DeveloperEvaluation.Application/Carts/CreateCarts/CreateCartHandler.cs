using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCartHandler(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper, IMediator mediator)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var productIds = command.CartItems.Select(c => c.ProductId).ToList();
        var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);

        var invalidIds = productIds.Except(products.Select(p => p.Id)).ToList();

        if (invalidIds.Count != 0)
            throw new InvalidOperationException($"Some product id's are invalid {string.Join(";", invalidIds)}");

        var cart = _mapper.Map<Cart>(command);

        foreach (var item in cart.CartItems)
        {
            item.UnitPrice = products.Single(p => p.Id == item.ProductId).Price;
        }

        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);

        await _mediator.Publish(new CartCreatedEvent(cart), cancellationToken);

        return result;
    }
}
