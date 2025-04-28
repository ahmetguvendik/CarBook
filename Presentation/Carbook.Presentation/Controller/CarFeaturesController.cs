using Carbook.Application.Features.CQRS.Queries.CarFeaturesQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarFeaturesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IMediator _mediator;

    public CarFeaturesController( IMediator mediator)
    {
         _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string id)
    {
        var values = await _mediator.Send(new GetCarFeaturesByCarIdQuery(id));
        return Ok(values);
    }
}