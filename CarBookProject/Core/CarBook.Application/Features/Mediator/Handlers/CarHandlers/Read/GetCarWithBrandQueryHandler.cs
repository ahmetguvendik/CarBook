using System;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Repositories;
using CarBook.Application.Repositories.CarRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Read
{
	public class GetCarWithBrandQueryHandler : IRequestHandler<GetCarWithBrandsQuery, List<GetCarWithBrandsQueryResult>>
    {
        private readonly ICarRepository _carRepository;
		public GetCarWithBrandQueryHandler(ICarRepository carRepository)
		{
            _carRepository = carRepository;
		}

        public async Task<List<GetCarWithBrandsQueryResult>> Handle(GetCarWithBrandsQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetCarWithBrands();
            return values.Select(x => new GetCarWithBrandsQueryResult
            {
                Id = x.Id,
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

