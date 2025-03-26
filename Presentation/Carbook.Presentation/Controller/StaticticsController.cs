using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaticticsController : Controller
{
    private readonly IMediator _mediator;

    public StaticticsController( IMediator mediator)
    {
         _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var value = await _mediator.Send(new GetCarCountQuery()); 
        return Ok(value);   
    }
}