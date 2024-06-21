using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailRecentBlogComponentPartial : ViewComponent
	{
		public _BlogDetailRecentBlogComponentPartial()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

