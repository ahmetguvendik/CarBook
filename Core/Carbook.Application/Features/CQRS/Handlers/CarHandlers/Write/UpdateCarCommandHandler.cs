using System;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using Carbook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Write
{
	public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
	{
        private readonly IRepository<Domain.Entities.Car> _repository;

        public UpdateCarCommandHandler(IRepository<Domain.Entities.Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.Id);
            car.Vites = request.Vites;
            car.Model = request.Model;
            car.Km = request.Km;
            car.Fuel = request.Fuel;
            car.DetailImageUrl = request.DetailImageUrl;
            car.CoverImageUrl = request.CoverImageUrl;
            car.BrandId = request.BrandId;
            car.Bagaj = request.Bagaj;
            await _repository.UpdateAsync(car);
        }
    }
}

