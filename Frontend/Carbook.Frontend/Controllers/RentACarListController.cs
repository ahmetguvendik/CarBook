using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class RentACarListController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}