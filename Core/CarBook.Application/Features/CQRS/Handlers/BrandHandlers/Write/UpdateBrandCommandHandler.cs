using Carbook.Application.Features.CQRS.Commands.BrandCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers.Write;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandler( IRepository<Brand> repository)
    {
         _repository = repository;
    }
    public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        brand.Name = request.Name;
        await _repository.UpdateAsync(brand);
    }
}