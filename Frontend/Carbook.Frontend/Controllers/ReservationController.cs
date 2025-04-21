using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.Controllers;

public class ReservationController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.v1 = "Rezervasyon";
        ViewBag.v2 = "Rezervasyon Islemleriniz Icin Formu Doldurunuz";
        return View();
    }
}