using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
               Bagaj = x.Bagaj,
               Vites = x.Vites,
               CoverImageUrl = x.CoverImageUrl,
               BrandId = x.BrandId,
               Fuel = x.Fuel,
               DetailImageUrl = x.DetailImageUrl,
               Km = x.Km,
               Koltuk = x.Koltuk,
               Model = x.Model
            }).ToList();
        }
    }
}

