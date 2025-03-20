using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.AboutCommands;


public class RemoveAboutCommand: IRequest
{
    public string Id { get; set; }

    public RemoveAboutCommand(string id)
    {
         Id = id;
    }
}