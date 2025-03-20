using Carbook.Application.Features.CQRS.Queries.CategoryQueries;
using Carbook.Application.Features.CQRS.Results.CategoryResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
{
    private readonly IRepository<Category> _categoryRepository;

    public GetCategoryByIdQueryHandler( IRepository<Category> categoryRepository)
    { 
         _categoryRepository = categoryRepository;
    }
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _categoryRepository.GetByIdAsync(request.Id);
        return new GetCategoryByIdQueryResult()
        {
            Id = values.Id,
            Name = values.Name,
        };
    }
}