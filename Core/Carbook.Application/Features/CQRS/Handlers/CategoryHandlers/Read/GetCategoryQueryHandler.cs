using Carbook.Application.Features.CQRS.Queries.CategoryQueries;
using Carbook.Application.Features.CQRS.Results.CategoryResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,List<GetCategoryQueryResult>>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryQueryHandler( IRepository<Category> categoryRepository)
    {
         _categoryRepository = categoryRepository;
    }
    public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var value = await _categoryRepository.GetAllAsync();
        return value.Select(x => new GetCategoryQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}