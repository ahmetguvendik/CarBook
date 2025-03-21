using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public class GetAllBlogWithAuthorandCategoryQuery: IRequest<List<GetAllBlogWithAuthorandCategoryResult>>
{
    
}