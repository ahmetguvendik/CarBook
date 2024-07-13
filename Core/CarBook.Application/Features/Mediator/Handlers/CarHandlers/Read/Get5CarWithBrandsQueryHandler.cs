using System;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Repositories.CarRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Read
{
	public class Get5CarWithBrandsQueryHandler : IRequestHandler<Get5CarWithBrandsQuery, List<Get5CarWithBrandsQueryResult>>
    {
        private readonly ICarRepository _carRepository;
        public Get5CarWithBrandsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Get5CarWithBrandsQueryResult>> Handle(Get5CarWithBrandsQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.Get5CarWithBrands();
            return values.Select(x => new Get5CarWithBrandsQueryResult
            {
                Bagaj = x.Bagaj,
                Vites = x.Vites,
                CoverImageUrl = x.CoverImageUrl,
                BrandName = x.Brand.Name,
                Fuel = x.Fuel,
                DetailImageUrl = x.DetailImageUrl,
                Km = x.Km,
                Koltuk = x.Koltuk,
                Model = x.Model
            }).ToList();
        }
    }
}

