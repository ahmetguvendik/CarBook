﻿using System;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
	{
        private readonly IRepository<CarBook.Domain.Entities.Features> _repository;
		public GetFeatureQueryHandler(IRepository<CarBook.Domain.Entities.Features> repository)
		{
            _repository = repository;
		}

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                Name = x.Name
            }).ToList();
        }
    }
}

