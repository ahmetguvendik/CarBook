using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.CategoryCommands;

public class UpdateCategoryCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}