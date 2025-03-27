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
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCarCount()
    {
        var value = await _mediator.Send(new GetCarCountQuery()); 
        return Ok(value);   
    }
    
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetLocationCount()
    {
        var value = await _mediator.Send(new GetLocationCountQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAuthorCount()
    {
        var value = await _mediator.Send(new GetAuthorCountQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlogCount()
    {
        var value = await _mediator.Send(new GetBlogCountQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetBrandCount()
    {
        var value = await _mediator.Send(new GetBrandCountQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAvgRentPriceForDaily()
    {
        var value = await _mediator.Send(new GetAvgRentPriceForDailyQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAvgRentPriceForWeekly()
    {
        var value = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAvgRentPriceForMonthly()    
    {
        var value = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCarCountByFuelElectric()    
    {
        var value = await _mediator.Send(new GetCarCountByFuelElectricQuery()); 
        return Ok(value);   
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCountByTranmissionIsAuto()    
    {
        var value = await _mediator.Send(new GetCountByTranmissionIsAutoQuery()); 
        return Ok(value);   
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCarCountByKmSmallerThan1000()    
    {
        var value = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query()); 
        return Ok(value);   
    }
}
