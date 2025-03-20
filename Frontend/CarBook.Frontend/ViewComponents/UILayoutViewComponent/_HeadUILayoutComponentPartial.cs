using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.UILayoutViewComponent;

public class _HeadUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}