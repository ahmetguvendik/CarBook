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
	public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<Domain.Entities.FooterAdress> _repository;
        public GetFooterAdressByIdQueryHandler(IRepository<Domain.Entities.FooterAdress> repository)
        {
            _repository = repository;
        }


        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult()
            {
                Id = value.Id,
                Adress = value.Adress,
                Description = value.Description,
                Email = value.Email,
                FacebookLink = value.FacebookLink,
                InstagramLink = value.InstagramLink,
                PhoneNumber = value.PhoneNumber,
                TwitterLink = value.TwitterLink
            };
        }
    }
}

