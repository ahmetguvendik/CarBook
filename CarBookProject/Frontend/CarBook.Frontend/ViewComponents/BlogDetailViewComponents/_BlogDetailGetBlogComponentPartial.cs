using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailGetBlogComponentPartial : ViewComponent
	{
		public _BlogDetailGetBlogComponentPartial()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

