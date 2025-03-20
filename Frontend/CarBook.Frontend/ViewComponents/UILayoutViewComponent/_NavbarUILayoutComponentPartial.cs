using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.UILayoutViewComponent;

public class _NavbarUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}