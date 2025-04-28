using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;

public class CreateCarFeauresCommand : IRequest
{
    public string CarId { get; set; }
    public string FeaturesId { get; set; }  
    public bool IsAvaible { get; set; }	    
}