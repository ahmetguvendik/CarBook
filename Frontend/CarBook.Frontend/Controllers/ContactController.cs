using System.Text;
using CarBook.Dto.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bizimle İletişime Geçin";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            createContactDto.DateTime = DateTime.UtcNow;
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5128/api/Contact", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About");
            }

            return View();
            
        }
    }
