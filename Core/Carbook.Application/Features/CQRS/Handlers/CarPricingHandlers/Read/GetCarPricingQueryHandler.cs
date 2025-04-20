using System;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Repositories.CarPricingReposiyories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
	public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery,List<GetCarPricingQueryResult>>
	{
        private readonly ICarPricingRepository _carPricingRepository;
		public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
		{
            _carPricingRepository = carPricingRepository;
		}

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricingsWithCarDailyPrice();
            return values.Select(x => new GetCarPricingQueryResult
            {
                Id = x.Id,
                BrandName = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                Price =x.Price

            }).ToList();
        }
    }
}

