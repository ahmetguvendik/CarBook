﻿using System;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read
{
	public class GetAboutByIdQueryHandler
	{
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAboutByIdQueryResult
			{
				Id = values.Id,
				ImageURL = values.ImageURL,
				Description = values.Description,
				Title = values.Title
			};
		}
	}
}

