using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.AdminUIViewComponents;

public class _AdminHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }   
}