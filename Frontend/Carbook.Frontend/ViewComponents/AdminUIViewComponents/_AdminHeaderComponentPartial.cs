using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.AdminUIViewComponents;

public class _AdminHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }  
}