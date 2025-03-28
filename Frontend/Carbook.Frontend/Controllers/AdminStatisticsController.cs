using CarBook.Dto.ServiceDTOs;
using Carbook.Dto.StatisticsDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.Frontend.Controllers;

public class AdminStatisticsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminStatisticsController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;     
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        
        var response = await client.GetAsync("http://localhost:5128/api/Statictics/GetCarCount");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
            ViewBag.v1 = values.carCount;
        }
        
        var response1 = await client.GetAsync("http://localhost:5128/api/Statictics/GetLocationCount");
        if (response1.IsSuccessStatusCode)
        {
            var jsonData1 = await response1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData1);
            ViewBag.v2 = values1.locationCount; 
        }
        
        var response2 = await client.GetAsync("http://localhost:5128/api/Statictics/GetAuthorCount");   
        if (response2.IsSuccessStatusCode)
        {
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
            ViewBag.v3 = values2.authorCount; 
        }
        
        var response3 = await client.GetAsync("http://localhost:5128/api/Statictics/GetBlogCount");   
        if (response3.IsSuccessStatusCode)
        {
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
            ViewBag.v4 = values3.blogCount; 
        }
        
        var response4 = await client.GetAsync("http://localhost:5128/api/Statictics/GetBrandCount");   
        if (response4.IsSuccessStatusCode)
        {
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
            ViewBag.v5 = values4.brandCount; 
        }
        
        var response5 = await client.GetAsync("http://localhost:5128/api/Statictics/GetAvgRentPriceForDaily");   
        if (response5.IsSuccessStatusCode)
        {
            var jsonData5 = await response5.Content.ReadAsStringAsync();
            var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
            ViewBag.v6 = values5.avgPriceForDaily.ToString("0.00"); 
        }
        
        var response6 = await client.GetAsync("http://localhost:5128/api/Statictics/GetAvgRentPriceForWeekly");   
        if (response6.IsSuccessStatusCode)
        {
            var jsonData6 = await response6.Content.ReadAsStringAsync();
            var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
            ViewBag.v7 = values6.avgPriceForWeekly.ToString("0.00"); 
        }
        
        var response7 = await client.GetAsync("http://localhost:5128/api/Statictics/GetAvgRentPriceForMonthly");   
        if (response7.IsSuccessStatusCode)
        {
            var jsonData7 = await response7.Content.ReadAsStringAsync();
            var values7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
            ViewBag.v8 = values7.avgPriceForMonthly.ToString("0.00"); 
        }

        var response8 = await client.GetAsync("http://localhost:5128/api/Statictics/GetCarCountByFuelElectric");   
        if (response8.IsSuccessStatusCode)
        {
            var jsonData8 = await response8.Content.ReadAsStringAsync();
            var values8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
            ViewBag.v9 = values8.fuelEletricCount; 
        }
        
        var response9 = await client.GetAsync("http://localhost:5128/api/Statictics/GetCountByTranmissionIsAuto");   
        if (response9.IsSuccessStatusCode)
        {
            var jsonData9 = await response9.Content.ReadAsStringAsync();
            var values9 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
            ViewBag.v10 = values9.autoCarCount; 
        }
        
        var response10 = await client.GetAsync("http://localhost:5128/api/Statictics/GetCarCountByKmSmallerThan1000");   
        if (response10.IsSuccessStatusCode)
        {
            var jsonData10 = await response10.Content.ReadAsStringAsync();
            var values10 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);
            ViewBag.v11 = values10.countKmSmallerThan1000; 
        }
        
        return View();
    }
}