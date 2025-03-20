using System;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery,GetFeatureByIdQueryResult>
	{
        private readonly IRepository<Domain.Entities.Features> _repository;
		public GetFeatureByIdQueryHandler(IRepository<Domain.Entities.Features> repository)
		{
            _repository = repository;
		}

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult()
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }
}

