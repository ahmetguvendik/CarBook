using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.RentACarViewComponents;

public class _RentACarComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}