using Microsoft.AspNetCore.Mvc;

namespace Carbook.Frontend.ViewComponents.UILayoutViewComponent;

public class _MainCoverUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}