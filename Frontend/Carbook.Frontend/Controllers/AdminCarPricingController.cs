using System.Text;
using CarBook.Dto.AdminDTOs;
using CarBook.Dto.CarPricingDTOs;
using CarBook.Dto.PricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminCarPricingController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarPricingController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/CarPricing/GetAll");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetCarPricingWithCarDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateCarPricing()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Car");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
        List<SelectListItem> cars = (from x in values
            select new SelectListItem   
            {
                Text = x.Model,
                Value = x.Id.ToString()
            }).ToList();
        
        ViewBag.Cars = cars;
        
        var response2 = await client.GetAsync("http://localhost:5128/api/Pricing");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData2);
        List<SelectListItem> pricing = (from x in values2
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        
        ViewBag.Pricing = pricing;
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarPricing(CreateCarPricingDto createCarPricingDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCarPricingDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/CarPricing", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCarPricing");
        }

        return View();
           
    }
}