using System.Text;
using CarBook.Dto.AdminDTOs;
using Carbook.Dto.CarFeaturesDTOs;
using Carbook.Dto.FeaturesDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminCarDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/CarFeatures?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarFeaturesDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(List<ResultCarFeaturesDto> model)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            
            foreach (var item in model)
            {
                var updateDto = new UpdateCarFeaturesDto
                {
                    Id = item.Id,
                    IsAvaible = item.IsAvaible
                };

                var jsonData = JsonConvert.SerializeObject(updateDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5128/api/CarFeatures", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Güncelleme başarısız: {response.StatusCode}");
                }
            }

            TempData["Message"] = "Özellikler başarıyla güncellendi";
            return RedirectToAction("Index", new { id = model.FirstOrDefault()?.CarId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Bir hata oluştu: " + ex.Message;
            return RedirectToAction("Index", new { id = model.FirstOrDefault()?.CarId });
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeatures(string carId, string[] selectedFeatures)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            
            // Önce mevcut özellikleri sil
            await client.DeleteAsync($"http://localhost:5128/api/CarFeatures/DeleteByCarId/{carId}");

            // Seçilen özellikleri ekle
            foreach (var featureId in selectedFeatures)
            {
                var createDto = new CreateCarFeaturesDto
                {
                    CarId = carId,
                    FeaturesId = featureId,
                    IsAvaible = true
                };

                var jsonData = JsonConvert.SerializeObject(createDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:5128/api/CarFeatures", content);
            }

            TempData["Message"] = "Özellikler başarıyla güncellendi";
            return RedirectToAction("Index", new { id = carId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Bir hata oluştu: " + ex.Message;
            return RedirectToAction("Index", new { id = carId });
        }
    }

    [HttpGet]
    public async Task<IActionResult> CreateFeatures()
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
            
        var response2 = await client.GetAsync("http://localhost:5128/api/Feature");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultFeaturesDto>>(jsonData2);
        List<SelectListItem> features = (from x in values2
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        
        ViewBag.Features = features;
        
        return View();  
    }
    
    public async Task<IActionResult> CreateFeatures(CreateCarFeaturesDto createCarFeaturesDto)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarFeaturesDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5128/api/CarFeatures", stringContent);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
            
            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = result.message });
            }
            else
            {
                return Json(new { success = false, message = result.message });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
        }
    }
}

public class CarFeaturesViewModel
{
    public string CarId { get; set; }
    public List<ResultFeaturesDto> AllFeatures { get; set; }
    public List<ResultCarFeaturesDto> CarFeatures { get; set; }
}