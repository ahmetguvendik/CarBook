using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Dto.BannerDTOs;
using CarBook.Dto.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminContactController(IHttpClientFactory httpClientFactory)
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

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBannerDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7070/api/Banner", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner");
            }

            return View();
        }

        public async Task<IActionResult> UpdateBanner(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMeesage = await client.GetAsync($"http://localhost:7070/api/Banner/{id}");
            if (responseMeesage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData1);
                return View(values1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto, string id)
        {
            updateBannerDto.Id = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7070/api/Banner", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBrand");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBanner(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:7070/api/Banner?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner");
            }
            return View();

        }
    }
}

