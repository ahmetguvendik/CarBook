using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CategoryCommands;

public class CreateCategoryCommand : IRequest
{
    public string Name { get; set; }
}