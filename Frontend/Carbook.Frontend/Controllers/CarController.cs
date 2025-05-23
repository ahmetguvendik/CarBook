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
    public async Task<IActionResult> Index(string id)
    {
        ViewBag.v1 = "Arabalar";
        ViewBag.v2 = "Kendinize Göre Araba Bulun";
        ViewBag.v3 = id;
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

    public IActionResult CarDetail(string id)
    {
        ViewBag.v1 = "Araba Detay";
        ViewBag.v2 = "Secitiginiz Arabanin Detaylari";
        ViewBag.v3 = id;
        return View();
    }
}