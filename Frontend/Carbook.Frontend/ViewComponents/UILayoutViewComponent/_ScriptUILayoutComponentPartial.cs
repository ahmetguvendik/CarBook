using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.UILayoutViewComponent;

public class _ScriptUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}