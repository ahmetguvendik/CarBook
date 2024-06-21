using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailCategoryComponentPartial : ViewComponent
	{
		public _BlogDetailCategoryComponentPartial()
		{
		}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

