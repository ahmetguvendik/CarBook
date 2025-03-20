using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.UILayoutViewComponent;

public class _FooterUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}