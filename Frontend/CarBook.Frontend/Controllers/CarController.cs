using CarBook.Dto.CarPricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class CarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Arabalar";
        ViewBag.v2 = "Kendinize Göre Araba Bulun";
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/CarPricing");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetCarPricingWithCarDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}