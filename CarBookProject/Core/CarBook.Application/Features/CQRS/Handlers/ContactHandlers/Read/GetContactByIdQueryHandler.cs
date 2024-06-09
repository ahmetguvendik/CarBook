using System;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
	public class GetContactByIdQueryHandler
	{
		private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
		{
			var contact = await _repository.GetByIdAsync(query.Id);
			return new GetContactByIdQueryResult()
			{
				DateTime = contact.DateTime,
				Description = contact.Description,
				Email = contact.Email,
				Name = contact.Name,
				Subject = contact.Subject
			};
		}
	}
}

