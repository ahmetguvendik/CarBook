using System.Text;
using CarBook.Dto.AboutDTOs;
using CarBook.Dto.AdminDTOs;
using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ResultBrandDto = CarBook.Dto.BrandDTOs.ResultBrandDto;

namespace Carbook.Frontend.Controllers;

public class AdminCarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarController( IHttpClientFactory clientFactory )
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Car/GetCarWithBrands");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateCar()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Brand");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        List<SelectListItem> brands = (from x in values
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Brands = brands;
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCarDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Car", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCar");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCar(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Brand");
         var jsonData = await response.Content.ReadAsStringAsync();
         var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
         List<SelectListItem> brandValue = (from x in values
             select new SelectListItem
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();
         ViewBag.Brands = brandValue;
         
         var responseMesage = await client.GetAsync($"http://localhost:5128/api/Car/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCarDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Car", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCar");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveCar(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Car?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
       return RedirectToAction("Error", "Home");
    }
}