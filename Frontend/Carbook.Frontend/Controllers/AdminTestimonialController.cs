using System.Text;
using CarBook.Dto.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminTestimonialController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminTestimonialController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Testimonial");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateTestimonial()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Testimonial", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminTestimonial");   
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(string id)
    {
        var client = _httpClientFactory.CreateClient();
         var response = await client.GetAsync($"http://localhost:5128/api/Testimonial/{id}");
         if (response.IsSuccessStatusCode)
         {
             var jsonData1 = await response.Content.ReadAsStringAsync();
             var values1 = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData1);
             return View(values1);
         }
              return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Testimonial", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminTestimonial");   
        }

        return View();
    }
    
    public async Task<IActionResult> RemoveTestimonial(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Testimonial?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminTestimonial");   
        }
       return RedirectToAction("Error", "Home");
    }
}