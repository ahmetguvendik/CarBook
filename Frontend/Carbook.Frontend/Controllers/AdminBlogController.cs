using System.Text;
using Carbook.Dto.AuthorDTOs;
using CarBook.Dto.BlogDTOs;
using CarBook.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminBlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminBlogController( IHttpClientFactory clientFactory )
    {
        _httpClientFactory = clientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Blog/GetAllBlogWithAuthorandCategory");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGetAllBlogWithAuthorAndCategory>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateBlog()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Author");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
        List<SelectListItem> author = (from x in values
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Author = author;
        
        var client2 = _httpClientFactory.CreateClient();
        var response2 = await client2.GetAsync("http://localhost:5128/api/Category");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
        List<SelectListItem> category = (from x in values2
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Category = category;
        
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
    {
        createBlogDto.CreatedTime  = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createBlogDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Blog", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBlog");    
        }

        return View();
           
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateBlog(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Author");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
        List<SelectListItem> author = (from x in values
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Author = author;
        
        var client2 = _httpClientFactory.CreateClient();
        var response2 = await client2.GetAsync("http://localhost:5128/api/Category");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
        List<SelectListItem> category = (from x in values2
            select new SelectListItem   
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Category = category;
         
        var responseMesage = await client.GetAsync($"http://localhost:5128/api/Blog/{id}");
        if (responseMesage.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMesage.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData1);
            return View(values1);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
    {
        updateBlogDto.CreatedTime  = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBlogDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5128/api/Blog", stringContent);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminBlog");
        }

        return View();
    }

    
    public async Task<IActionResult> RemoveBlog(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Blog?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
       return RedirectToAction("Error", "Home");
    }
}