using System.Text;
using CarBook.Dto.CategoryDTOs;
using CarBook.Dto.FooterAdressDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminFooter : Controller
    {
        // GET: /<controller>/
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminFooter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/FooterAdress");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResulFooterAdressDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateFooter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterAdressDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7070/api/FooterAdress", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFooter");
            }

            return View();
        }

        public async Task<IActionResult> UpdateFooter(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMeesage = await client.GetAsync($"http://localhost:7070/api/FooterAdress/{id}");
            if (responseMeesage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdateFooterAdressDto>(jsonData1);
                return View(values1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooter(UpdateFooterAdressDto updateBrandDto, string id)
        {
            updateBrandDto.Id = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7070/api/FooterAdress", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFooter");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFooter(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:7070/api/FooterAdress?id={id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "AdminFooter");
            }
            return View();

        }
    }
}

