using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.BrandCommands;

public class UpdateBrandCommand : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
}