using Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CarFeauresHandlers.Write;

public class UpdateCarFeaturesCommandHandler : IRequestHandler<UpdateCarFeaturesCommand>
{
    private readonly IRepository<CarFeatures> _repository;

    public UpdateCarFeaturesCommandHandler(IRepository<CarFeatures> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarFeaturesCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value != null)
        {
            value.IsAvaible = request.IsAvaible;
            await _repository.UpdateAsync(value);
            await _repository.SaveChangesAsync();
        }
    }
} 