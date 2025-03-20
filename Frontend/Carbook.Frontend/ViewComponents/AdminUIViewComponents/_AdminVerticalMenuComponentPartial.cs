using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.AdminUIViewComponents;

public class _AdminVerticalMenuComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }  
}