using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class ServiceController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.v1 = "Hizmetler";
        ViewBag.v2 = "Sizler İçin Sunduklarımız";
        return View();
    }
}