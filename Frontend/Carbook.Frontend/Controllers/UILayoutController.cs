using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}