using System;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Features.Mediator.Results.CarResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
	public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        
        private readonly IRepository<Author> _repository;
        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetAllAsync();
            return author.Select(x => new GetAuthorQueryResult
            {
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).ToList();
        }
    }
}

