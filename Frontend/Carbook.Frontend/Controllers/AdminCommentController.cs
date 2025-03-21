using System.Text;
using CarBook.Dto.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminCommentController : Controller
{
   private readonly IHttpClientFactory _httpClientFactory;

    public AdminCommentController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Comment/GetAllCommentsWithBlogTitle");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentWİthBlogTitle>>(jsonData);
            return View(values);
        }
        return View();
    }
    
    
    public async Task<IActionResult> RemoveComment(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"http://localhost:5128/api/Comment?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "AdminComment");
        }
       return RedirectToAction("Error", "Home");
    }
}