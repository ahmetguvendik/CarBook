using System.Text;
using Carbook.Dto.AppUserDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterController( IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateUserDto createUserDto)
    {
        createUserDto.AppRoleId = "2";
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createUserDto);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Register", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login");
        }

        return View();
    }
}