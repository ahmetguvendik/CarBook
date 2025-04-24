using Carbook.Application.Features.CQRS.Commands.BrandCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers.Write;

public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand>
{
    private readonly IRepository<Brand> _repository;

    public RemoveBrandCommandHandler( IRepository<Brand> repository)
    {
         _repository = repository;
    }
    public async Task Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}