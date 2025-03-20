using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.LocationCommands;

public class UpdateLocationCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }	
}