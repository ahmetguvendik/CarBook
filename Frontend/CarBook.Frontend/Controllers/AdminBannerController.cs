using System.Text;
using CarBook.Dto.BannerDTOs;
using CarBook.Dto.FooterAdressDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminBannerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminBannerController( IHttpClientFactory clientFactory )
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Banner");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateBanner()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Banner", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBanner");    
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBanner(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Banner");
         var jsonData = await response.Content.ReadAsStringAsync();
         var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
         List<SelectListItem> brandValue = (from x in values
             select new SelectListItem
             {
                 Text = x.Title,
                 Value = x.Id.ToString()
             }).ToList();
         ViewBag.Brands = brandValue;
         
         var responseMesage = await client.GetAsync($"http://localhost:5128/api/Banner/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBannerDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Banner", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBanner");    
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveBanner(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Banner?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
       return RedirectToAction("Error", "Home");
    }
}