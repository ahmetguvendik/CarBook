using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Carbook.Application.Features.CQRS.Commands.CarFeaturesCommands;
using Carbook.Application.Features.CQRS.Queries.CarFeaturesQueries;
using Carbook.Application.Features.CQRS.Results.CarFeaturesResults;
using Carbook.Dto.CarFeaturesDTOs;

namespace Carbook.API.Controllers
{
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
        public async Task<IActionResult> GetCarFeaturesByCarId([FromQuery] string id)
        {
            var values = await _mediator.Send(new GetCarFeaturesByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatures(CreateCarFeaturesDto createCarFeaturesDto)
        {
            await _mediator.Send(new CreateCarFeaturesCommand
            {
                CarId = createCarFeaturesDto.CarId,
                FeaturesId = createCarFeaturesDto.FeaturesId,
                IsAvaible = createCarFeaturesDto.IsAvaible
            });
            return Ok("Araç özelliği başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarFeatures(UpdateCarFeaturesDto updateCarFeaturesDto)
        {
            await _mediator.Send(new UpdateCarFeaturesCommand
            {
                Id = updateCarFeaturesDto.Id,
                IsAvaible = updateCarFeaturesDto.IsAvaible
            });
            return Ok("Araç özelliği başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarFeatures(string id)
        {
            await _mediator.Send(new RemoveCarFeaturesCommand(id));
            return Ok("Araç özelliği başarıyla silindi");
        }

        [HttpDelete("DeleteByCarId/{carId}")]
        public async Task<IActionResult> RemoveCarFeaturesByCarId(string carId)
        {
            await _mediator.Send(new RemoveCarFeaturesByCarIdCommand(carId));
            return Ok("Araç özellikleri başarıyla silindi");
        }

        [HttpPost("ResetAll")]
        public async Task<IActionResult> ResetAllCarFeatures()
        {
            await _mediator.Send(new ResetCarFeaturesCommand());
            return Ok("Tüm araç özellikleri başarıyla sıfırlandı ve yeniden oluşturuldu.");
        }
    }
} 