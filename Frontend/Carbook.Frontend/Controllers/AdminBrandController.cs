using System.Text;
using CarBook.Dto.BrandDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;


public class AdminBrandController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminBrandController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Brand");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateBrand()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBrandDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Brand", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBrand");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Brand/{id}");
         if (response.IsSuccessStatusCode)
         {
             var jsonData1 = await response.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBrandDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Brand", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBrand");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveBrand(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Brand?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBrand");
        }
       return RedirectToAction("Error", "Home");
    }
}