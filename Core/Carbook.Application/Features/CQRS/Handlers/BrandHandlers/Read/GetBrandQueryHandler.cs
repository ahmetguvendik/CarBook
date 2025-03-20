using Carbook.Application.Features.CQRS.Queries.BrandQueries;
using Carbook.Application.Features.CQRS.Results.BrandResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers.Read;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
{
    private readonly IRepository<Brand> _repository;

    public GetBrandQueryHandler( IRepository<Brand> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetBrandQueryResult
        {
           Id = x.Id,
           Name = x.Name,
        }).ToList();
    }
    
}