using System;
using CarBook.Dto.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Frontend.ViewComponents.BlogViewComponents
{
	public class _Get3BlogWithAuthorComponentPartial : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _Get3BlogWithAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Blog/Get3BlogWithAuthor");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGet3BlogWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

