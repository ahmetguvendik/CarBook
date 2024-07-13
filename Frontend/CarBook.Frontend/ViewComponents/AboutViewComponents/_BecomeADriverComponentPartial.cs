using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

