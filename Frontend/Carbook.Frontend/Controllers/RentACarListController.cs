using Carbook.Dto.FilterRentACar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class RentACarListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RentACarListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(string id)
    {
        var book_pick_date = TempData["book_pick_date"];
        var book_off_date = TempData["book_off_date"];
        var time_pick = TempData["time_pick"];
        var time_off_pick = TempData["time_off_pick"];
        var location_id = TempData["locationId"];
        id = location_id.ToString();
        
        ViewBag.book_pick_date = book_pick_date;
        ViewBag.book_off_date = book_off_date;
        ViewBag.time_pick = time_pick;
        ViewBag.time_off_pick = time_off_pick;
        ViewBag.location_id = location_id.ToString();
        
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/RentACar?LocationID={id}&Avaible=true");   
        
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFilterRentACarDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}