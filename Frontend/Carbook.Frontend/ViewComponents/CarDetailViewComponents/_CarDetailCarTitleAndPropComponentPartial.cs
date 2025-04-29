using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.ViewComponents.CarDetailViewComponents;

public class _CarDetailCarTitleAndPropComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CarDetailCarTitleAndPropComponentPartial( IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        ViewBag.v3 = id;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/Car/GetCarWithBrandsById?id={id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCarWithBrandByIdDto>(jsonData);
            return View(values);
        }
        return View();
    }
}