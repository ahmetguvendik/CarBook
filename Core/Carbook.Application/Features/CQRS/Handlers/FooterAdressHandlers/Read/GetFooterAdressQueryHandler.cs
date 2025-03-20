using System;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers.Read
{
	public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<CarBook.Domain.Entities.FooterAdress> _repository;
        public GetFooterAdressQueryHandler(IRepository<CarBook.Domain.Entities.FooterAdress> repository)
        {
            _repository = repository;
        }



        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAdressQueryResult
            {
                Id = x.Id,
                Adress = x.Adress,
                Description = x.Description,
                Email = x.Email,
                FacebookLink = x.FacebookLink,
                InstagramLink = x.InstagramLink,
                PhoneNumber = x.PhoneNumber,
                TwitterLink = x.TwitterLink
            }).ToList();
        }
    }
}

