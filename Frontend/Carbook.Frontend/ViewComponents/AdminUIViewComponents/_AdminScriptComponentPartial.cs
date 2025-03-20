using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.AdminUIViewComponents;

public class _AdminScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }  
}