using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Dto.BrandDTOs;
using CarBook.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{

        public class AdminCategoryController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;
            public AdminCategoryController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7070/api/Category");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                    return View(values);
                }
                return View();
            }

            public IActionResult CreateCategory()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategory(CreateCategoryDto createBrandDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBrandDto);
                StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7070/api/Category", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminCategory");
                }

                return View();
            }

            public async Task<IActionResult> UpdateCategory(string id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMeesage = await client.GetAsync($"https://localhost:7070/api/Category/{id}");
                if (responseMeesage.IsSuccessStatusCode)
                {
                    var jsonData1 = await responseMeesage.Content.ReadAsStringAsync();
                    var values1 = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData1);
                    return View(values1);
                }

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateBrandDto, string id)
            {
                updateBrandDto.Id = id;
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBrandDto);
                StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, "application/json");
                var response = await client.PutAsync("https://localhost:7070/api/Category", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminCategory");
                }

                return View();
            }

            [HttpGet]
            public async Task<IActionResult> RemoveCategory(string id)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"https://localhost:7070/api/Category?id={id}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "AdminCategory");
                }
                return View();

            }
        }
    }


