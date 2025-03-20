using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}