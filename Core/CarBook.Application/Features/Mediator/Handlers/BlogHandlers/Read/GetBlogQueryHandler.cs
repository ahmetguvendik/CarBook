using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
	public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery,List<GetBlogQueryResult>>
	{
        private readonly IRepository<Blog> _repository;
		public GetBlogQueryHandler(IRepository<Blog> repository)
		{
            _repository = repository;
		}

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAllAsync();
            return blog.Select(x => new GetBlogQueryResult
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedTime = x.CreatedTime,
                Title = x.Title,
                Description = x.Description
            }).ToList();
        }
    }
}

