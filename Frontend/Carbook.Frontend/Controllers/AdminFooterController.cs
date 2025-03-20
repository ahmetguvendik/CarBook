using System.Text;
using CarBook.Dto.FooterAdressDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminFooterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminFooterController( IHttpClientFactory clientFactory )
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/FooterAdress");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResulFooterAdressDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateFooter()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateFooter(CreateFooterAdressDto createFooterAdressDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFooterAdressDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/FooterAdress", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminFooter");
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFooter(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/FooterAdress");
         var jsonData = await response.Content.ReadAsStringAsync();
         var values = JsonConvert.DeserializeObject<List<ResulFooterAdressDto>>(jsonData);
         List<SelectListItem> brandValue = (from x in values
             select new SelectListItem
             {
                 Text = x.PhoneNumber,
                 Value = x.Id.ToString()
             }).ToList();
         ViewBag.Brands = brandValue;
         
         var responseMesage = await client.GetAsync($"http://localhost:5128/api/FooterAdress/{id}");
         if (responseMesage.IsSuccessStatusCode)
         {
             var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateFooterAdressDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateFooter(UpdateFooterAdressDto updateFooterAdressDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFooterAdressDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/FooterAdress", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminFooter");
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveFooter(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/FooterAdress?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
       return RedirectToAction("Error", "Home");
    }
}