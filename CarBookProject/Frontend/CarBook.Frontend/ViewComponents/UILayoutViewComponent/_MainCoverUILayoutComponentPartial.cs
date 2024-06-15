using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents
{
	public class _MainCoverUILayoutComponentPartial : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

