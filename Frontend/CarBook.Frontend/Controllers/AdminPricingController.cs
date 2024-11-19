using CarBook.Dto.ContactDTOs;
using System.Text;
using CarBook.Dto.PricingDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.BannerDTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Pricing");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreatePricing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7070/api/Pricing", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing");
            }

            return View();
        }

        public async Task<IActionResult> UpdatePricing(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMeesage = await client.GetAsync($"http://localhost:7070/api/Pricing/{id}");
            if (responseMeesage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData1);
                return View(values1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricing, string id)
        {
            updatePricing.Id = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricing);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7070/api/Pricing", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemovePricing(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:7070/api/Pricing?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPricing");
            }
            return View();

        }
    }
}

