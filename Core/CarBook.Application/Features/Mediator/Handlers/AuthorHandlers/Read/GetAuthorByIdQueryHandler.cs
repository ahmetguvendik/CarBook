using System;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
	public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;
        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                Description = author.Description,
                ImageUrl = author.ImageUrl,
                Name = author.Name
            };
        }
    }
}

