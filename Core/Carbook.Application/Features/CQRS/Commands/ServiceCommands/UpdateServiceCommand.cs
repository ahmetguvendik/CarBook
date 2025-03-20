using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.ServiceCommands;

public class UpdateServiceCommand : IRequest
{
    public string Id { get; set; }

    public UpdateServiceCommand(string id)
    {
        Id = id;
    }
}