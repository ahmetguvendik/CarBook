using System.Text;
using CarBook.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminCategoryController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminCategoryController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Category");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateCategory()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCategoryDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Category", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCategory");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Category/{id}");
         if (response.IsSuccessStatusCode)
         {
             var jsonData1 = await response.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Category", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCategory");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveCategory(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Category?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminCategory");
        }
       return RedirectToAction("Error", "Home");
    }
}