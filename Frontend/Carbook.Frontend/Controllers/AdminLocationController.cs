using System.Text;
using Carbook.Dto.LocationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminLocationController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminLocationController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Location");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateLocation()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createLocationDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Location", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateLocation(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Location/{id}");
         if (response.IsSuccessStatusCode)
         {
             var jsonData1 = await response.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateLocationDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Location", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveLocation(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Location?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminLocation");
        }
       return RedirectToAction("Error", "Home");
    }
}