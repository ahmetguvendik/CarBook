using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}