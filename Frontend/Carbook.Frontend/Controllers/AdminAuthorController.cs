using System.Text;
using Carbook.Dto.AuthorDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminAuthorController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminAuthorController( IHttpClientFactory clientFactory )
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Author");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateAuthor()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createAuthorDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Author", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminAuthor");    
        }

        return View();
           
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAuthor(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/Author/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData1 = await response.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData1);
            return View(values1);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Author", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminAuthor");
        }

        return View();
    }
    public async Task<IActionResult> RemoveAuthor(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Author?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
       return RedirectToAction("Error", "Home");
    }
}