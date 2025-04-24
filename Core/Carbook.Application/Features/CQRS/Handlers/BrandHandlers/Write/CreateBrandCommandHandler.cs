using Carbook.Application.Features.CQRS.Commands.BrandCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers.Write;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
{
    private readonly IRepository<Brand> _repository;

    public CreateBrandCommandHandler( IRepository<Brand> repository)
    {
         _repository = repository;
    }
    public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand();
        brand.Id = Guid.NewGuid().ToString();
        brand.Name = request.Name;
        await _repository.CreateAsync(brand);
    }
}