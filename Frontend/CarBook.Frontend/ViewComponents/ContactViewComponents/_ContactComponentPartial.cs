using System;
using CarBook.Dto.AboutDTOs;
using CarBook.Dto.ContactDTOs;
using CarBook.Dto.FooterAdressDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Frontend.ViewComponents.ContactViewComponents
{
	public class _ContactComponentPartial : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}

