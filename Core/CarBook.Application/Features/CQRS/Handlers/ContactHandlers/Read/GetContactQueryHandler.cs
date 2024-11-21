using System;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
	public class GetContactQueryHandler
	{
		private readonly IRepository<Contact> _repository;
		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetContactQueryResult>> Handle()
		{
			var contact = await _repository.GetAllAsync();
			return contact.Select(x => new GetContactQueryResult
			{
				
				Email = x.Email,
				DateTime = x.DateTime,
				Description = x.Description,
				Name = x.Name,
				Subject = x.Subject

			}).ToList();
		}
	}
}

