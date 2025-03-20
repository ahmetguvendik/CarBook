using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.ServiceCommands;


public class RemoveServiceCommand : IRequest
{
    public string Id { get; set; }

    public RemoveServiceCommand(string id)
    {
        Id = id;
    }
}