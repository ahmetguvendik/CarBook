using Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CarFeauresHandlers.Write;

public class CreateCarFeaturesCommandHandler : IRequestHandler<CreateCarFeauresCommand>
{
    private readonly IRepository<CarFeatures> _repository;

    public CreateCarFeaturesCommandHandler(IRepository<CarFeatures> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCarFeauresCommand request, CancellationToken cancellationToken)
    {
        // Check if the car-feature combination already exists
        var existingFeature = await _repository.GetAllAsync();
        if (existingFeature.Any(x => x.CarId == request.CarId && x.FeaturesId == request.FeaturesId))
        {
            throw new Exception("Bu araba için bu özellik zaten eklenmiş.");
        }

        var value = new CarFeatures();
        value.Id = Guid.NewGuid().ToString();
        value.CarId = request.CarId;
        value.FeaturesId = request.FeaturesId;
        value.IsAvaible = request.IsAvaible;
        await _repository.CreateAsync(value);
        await _repository.SaveChangesAsync();
    }
}