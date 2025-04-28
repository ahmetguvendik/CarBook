using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;

public class UpdateCarFeaturesCommand : IRequest
{
    public string Id { get; set; }
    public bool IsAvaible { get; set; }
} 