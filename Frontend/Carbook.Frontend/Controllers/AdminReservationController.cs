using System.Text;
using Carbook.Application.Services;
using Carbook.Dto.ReservartionDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IEmailService _emailService;

    public AdminReservationController(IHttpClientFactory httpClientFactory, IEmailService emailService)
    {
         _httpClientFactory = httpClientFactory;
          _emailService = emailService; 
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5128/api/Reservation");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultReservationResult>>(jsonData);
            return View(values);
        }
        return View();
    }
        
    
    public async Task<IActionResult> AprovedReservation(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/Reservation/{id}");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ResultReservationResult>(jsonData);
        
        var updateObj = new
        {
            Id = id,
            Statues = "Onaylandı"
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(updateObj), System.Text.Encoding.UTF8, "application/json");
        var putResponse = await client.PutAsync($"http://localhost:5128/api/Reservation/{id}", jsonContent);
        if (putResponse.IsSuccessStatusCode)
        {
            await _emailService.SendApprovedEmailAsync(values.Email, "BASVURUNUZ ONAYLANMISTIR. ILGILI LOKASYONA GIDIP ARACINIZI ALABILIRISNIZ");
            return RedirectToAction("Index", "AdminReservation");
        }

        return View();
    }

    public async Task<IActionResult> DenyedReservation(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/Reservation/{id}");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ResultReservationResult>(jsonData);
        var updateObj = new
        {
            Id = id,
            Statues = "Reddedildi"
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(updateObj), System.Text.Encoding.UTF8, "application/json");
        var putResponse = await client.PutAsync($"http://localhost:5128/api/Reservation/{id}", jsonContent);
        if (putResponse.IsSuccessStatusCode)
        {
            await _emailService.SendApprovedEmailAsync(values.Email, "MAALESEF BASVURU ONAYLANAMADI. BASKA ARAC VEYA LOKASYON SECEREK YENIDEN DENEYINIZ");
            return RedirectToAction("Index", "AdminReservation");
        }

        return View();
    }
}