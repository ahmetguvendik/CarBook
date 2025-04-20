using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CarPricingCommands;

public class CreateCarPricingCommad : IRequest
{
    public string CarId { get; set; }
    public string PricingId { get; set; }
    public decimal Price { get; set; }
    
}