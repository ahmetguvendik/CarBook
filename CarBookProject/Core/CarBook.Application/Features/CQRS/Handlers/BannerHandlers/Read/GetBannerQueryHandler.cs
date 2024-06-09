using System;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
	public class GetBannerQueryHandler
	{
		private readonly IRepository<Banner> _repository;
		public GetBannerQueryHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetBannerQueryResult>> Handle()
		{
			var banners = await _repository.GetAllAsync();
			return banners.Select(x => new GetBannerQueryResult
            {
				VideoDescription = x.VideoDescription,
				VideoURL = x.VideoURL,
                Description = x.Description,
                Title = x.Title
            }).ToList();
        }

    }
}

