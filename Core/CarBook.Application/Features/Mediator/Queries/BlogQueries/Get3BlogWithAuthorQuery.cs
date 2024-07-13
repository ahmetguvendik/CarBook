using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
	public class Get3BlogWithAuthorQuery : IRequest<List<Get3BlogWithAuthorQueryResult>>
	{

	}
}

