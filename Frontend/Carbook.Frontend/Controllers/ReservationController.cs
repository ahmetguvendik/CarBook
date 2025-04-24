using System.Text;
using Carbook.Application.Services;
using Carbook.Dto.LocationDTOs;
using Carbook.Dto.ReservartionDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class ReservationController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
   
    
    public ReservationController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
         
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(string id)
    {
        ViewBag.v1 = "Rezervasyon";
        ViewBag.v2 = "Rezervasyon Islemleriniz Icin Formu Doldurunuz";
        ViewBag.v3 = id;
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Location");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
        List<SelectListItem> locations = (from item in values
            select new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();
        ViewBag.Locations = locations;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationResult createReservationResult)
    {
        createReservationResult.Statues = "Rezevasyon Alindi ";
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createReservationResult);
        StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5128/api/Reservation", stringContent);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Rezervasyon Basvurunuz Alinmistir. Onaylaninca Mail Ile Bilgiler Iletilecektir!";
            return RedirectToAction("Index", "Default");    
        }

        return View();
    }

 
}