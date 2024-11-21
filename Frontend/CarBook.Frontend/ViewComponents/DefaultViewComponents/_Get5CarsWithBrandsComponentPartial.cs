using System;
using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Frontend.ViewComponents.DefaultViewComponents
{
	public class _Get5CarsWithBrandsComponentPartial : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _Get5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7070/api/Car/Get5CarWithBrands");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Result5CarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}

