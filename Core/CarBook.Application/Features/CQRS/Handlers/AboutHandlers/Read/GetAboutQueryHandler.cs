using System;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read
{
	public class GetAboutQueryHandler
	{
		private readonly IRepository<About> _repository;
		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetAboutQueryResult>> Handle()
        {
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult
			{
				Description = x.Description,
				Id = x.Id,
				ImageURL = x.ImageURL,
				Title = x.Title
			}).ToList();
        }
    }
}

