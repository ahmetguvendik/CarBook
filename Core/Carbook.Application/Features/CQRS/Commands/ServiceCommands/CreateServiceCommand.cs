using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.ServiceCommands;

public class CreateServiceCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconURL { get; set; }
}