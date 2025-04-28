using Carbook.Dto.CarFeaturesDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminCarDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarDetailController( IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    // GET
    public async Task<IActionResult> Index(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/CarFeatures?id="+id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarFeaturesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}