using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.BrandCommands;

public class RemoveBrandCommand : IRequest
{
    public string Id { get; set; }

    public RemoveBrandCommand(string id)
    {
         Id = id;
    }
}