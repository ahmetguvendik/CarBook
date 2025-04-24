using System.Net.Mime;
using Carbook.Dto.FilterRentACar;
using Carbook.Dto.LocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Location");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> locations = (from item in values
                select new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }).ToList();
            ViewBag.Locations = locations;
            return View();
    }

    [HttpPost]
    public IActionResult Index(RentACarFilterDto dto)
    {
         TempData["book_pick_date"] = dto.BookPickDate;
         TempData["book_off_date"] = dto.BookOffDate;
         TempData["time_pick"] = dto.TimePick;
         TempData["time_off_pick"] = dto.TimeOffPick;
         TempData["locationId"] = dto.LocationId;
        return RedirectToAction("Index","RentACarList");
    }
}