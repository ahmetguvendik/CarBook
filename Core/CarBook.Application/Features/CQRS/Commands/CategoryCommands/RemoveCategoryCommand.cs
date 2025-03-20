using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CategoryCommands;

public class RemoveCategoryCommand : IRequest
{
    public string Id { get; set; }

    public RemoveCategoryCommand(string id)
    {
         Id = id;
    }
}