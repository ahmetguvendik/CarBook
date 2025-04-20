using System;
using Carbook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;
namespace Carbook.Application.Features.CQRS.Handlers.CarPricingHandlers.Write;

public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommad>
{
    private readonly IRepository<CarPricing> _repository;

    public CreateCarPricingCommandHandler( IRepository<CarPricing> repository)
    {
         _repository = repository;
    }
    public async Task Handle(CreateCarPricingCommad request, CancellationToken cancellationToken)
    {
        var value = new CarPricing();
        value.Id = Guid.NewGuid().ToString();
        value.CarId  = request.CarId;
        value.PricingId = request.PricingId;
        value.Price = request.Price;
        await _repository.CreateAsync(value);
        await _repository.SaveChangesAsync();
    }
}