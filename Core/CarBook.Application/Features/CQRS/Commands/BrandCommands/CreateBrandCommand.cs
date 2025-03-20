using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.BrandCommands;

public class CreateBrandCommand : IRequest
{
    public string Name { get; set; }
}