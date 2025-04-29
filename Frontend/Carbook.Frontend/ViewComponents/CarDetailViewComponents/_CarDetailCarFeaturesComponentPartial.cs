using Carbook.Dto.CarFeaturesDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.ViewComponents.CarDetailViewComponents;

public class _CarDetailCarFeaturesComponentPartial : ViewComponent
{private readonly IHttpClientFactory _httpClientFactory;

    public _CarDetailCarFeaturesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5128/api/CarFeatures?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarFeaturesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}