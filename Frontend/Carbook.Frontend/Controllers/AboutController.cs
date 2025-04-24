using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.v1 = "Hakkımızda";
        ViewBag.v2 = "Vizyonumuz & Misyonumuz";
        return View();
    }
}