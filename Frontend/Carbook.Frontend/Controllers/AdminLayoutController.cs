using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class AdminLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}