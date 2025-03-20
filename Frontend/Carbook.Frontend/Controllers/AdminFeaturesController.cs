using System.Text;
using Carbook.Dto.FeaturesDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminFeaturesController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminFeaturesController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Feature");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeaturesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    public IActionResult CreateFeature()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeaturesDto createFeaturesDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeaturesDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Feature", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCar");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var responseMesage = await client.GetAsync($"http://localhost:5128/api/Feature/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateFeaturesDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeaturesDto updateFeaturesDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFeaturesDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Feature", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCar");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveFeature(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Feature?id={id}");  
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminFeatures");  
        }
       return RedirectToAction("Error", "Home");
    }
}