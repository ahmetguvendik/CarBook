using System;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : Controller
    {
        private readonly IMediator _mediator;
        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetCarPricingQuery());
            return Ok(value);
        }

    }

}