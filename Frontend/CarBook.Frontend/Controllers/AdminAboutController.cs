using System.Text;
using CarBook.Dto.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/About");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBannerDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/About", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout");
            }

            return View();
        }

        public async Task<IActionResult> UpdateAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMeesage = await client.GetAsync($"https://localhost:7070/api/About/{id}");
            if (responseMeesage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData1);
                return View(values1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateBannerDto, string id)
        {
            updateBannerDto.Id = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/About", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7070/api/About?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout");
            }
            return View();

        }
    }
}

