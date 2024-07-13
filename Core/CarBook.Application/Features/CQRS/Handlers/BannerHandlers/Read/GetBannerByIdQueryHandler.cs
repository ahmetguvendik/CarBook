using System;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
	public class GetBannerByIdQueryHandler
	{
		private readonly IRepository<Banner> _repository;
		public GetBannerByIdQueryHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
		{
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                VideoURL = values.VideoURL,
                VideoDescription = values.VideoDescription,
                Description = values.Description,
                Title = values.Title
            };
        }

    }
}

