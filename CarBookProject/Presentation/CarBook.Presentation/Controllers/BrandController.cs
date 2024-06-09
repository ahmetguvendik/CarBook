using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandQueryCommand _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandQueryCommand getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> PostBanner(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> PutAbout(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Silindi");
        }
    }
}

