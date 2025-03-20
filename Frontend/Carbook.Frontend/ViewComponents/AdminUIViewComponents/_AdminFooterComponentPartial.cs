using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.AdminUIViewComponents;

public class _AdminFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    } 
}