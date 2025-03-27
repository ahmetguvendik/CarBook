using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class AdminStatisticsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}