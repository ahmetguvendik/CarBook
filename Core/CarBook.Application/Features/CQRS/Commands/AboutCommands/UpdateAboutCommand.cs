using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.AboutCommands;

public class UpdateAboutCommand: IRequest
{
    public string Id { get; set; }  
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
}