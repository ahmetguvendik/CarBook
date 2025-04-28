using Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;
using Carbook.Application.Features.CQRS.Queries.CarFeaturesQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarFeaturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarFeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string id)
    {
        var values = await _mediator.Send(new GetCarFeaturesByCarIdQuery(id));
        return Ok(values);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateCarFeauresCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { message = "Özellik başarıyla eklendi!" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCarFeatures(UpdateCarFeaturesCommand command)
    {
        await _mediator.Send(command);
        return Ok("Car Feature successfully updated");
    }
}