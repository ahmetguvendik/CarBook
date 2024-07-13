using System;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Write
{
	public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
	{
        private readonly IRepository<Domain.Entities.Car> _repository;
        public CreateCarCommandHandler(IRepository<Domain.Entities.Car> repository)
        {
            _repository = repository;
        }



        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car();
            car.Id = Guid.NewGuid().ToString();
            car.Bagaj = request.Bagaj;
            car.BrandId = request.BrandId;
            car.CoverImageUrl = request.CoverImageUrl;
            car.DetailImageUrl = request.DetailImageUrl;
            car.Fuel = request.Fuel;
            car.Km = request.Km;
            car.Koltuk = request.Koltuk;
            car.Model = request.Model;
            car.Vites = request.Vites;
            await _repository.CreateAsync(car);
        }
    }
}

