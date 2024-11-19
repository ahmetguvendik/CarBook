using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Dto.BrandDTOs;
using CarBook.Dto.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Service");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7070/api/Service", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService");
            }

            return View();
        }

        public async Task<IActionResult> UpdateService(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMeesage = await client.GetAsync($"http://localhost:7070/api/Service/{id}");
            if (responseMeesage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData1);
                return View(values1);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto, string id)
        {
            updateServiceDto.Id = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7070/api/Service", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveService(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:7070/api/Service?id={id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "AdminService");
            }
            return View();

        }
    }
}

