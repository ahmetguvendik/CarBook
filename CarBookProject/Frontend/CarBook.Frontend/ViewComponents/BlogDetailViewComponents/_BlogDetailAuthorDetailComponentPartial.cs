using System;
using CarBook.Dto.BlogDTOs;
using CarBook.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailAuthorDetailComponentPartial : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAuthorDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7070/api/Blog/GetBlogWithAuthorByBlogId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResumeGetBlogWithAuthorByIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

