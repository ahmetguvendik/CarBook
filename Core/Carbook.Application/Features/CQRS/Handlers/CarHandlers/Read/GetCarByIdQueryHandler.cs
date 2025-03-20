using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly IRepository<Domain.Entities.Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Domain.Entities.Car> repository)
        {
            _repository = repository;
        }


        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCarByIdQueryResult()
            {
                Id = value.Id,
                Bagaj = value.Bagaj,
                Vites = value.Vites,
                CoverImageUrl = value.CoverImageUrl,
                BrandId = value.BrandId,
                Fuel = value.Fuel,
                DetailImageUrl = value.DetailImageUrl,
                Km = value.Km,
                Koltuk = value.Koltuk,
                Model = value.Model
            };
        }
    }
}

