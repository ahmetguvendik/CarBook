using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailAuthorDetailComponentPartial : ViewComponent
	{
		public _BlogDetailAuthorDetailComponentPartial()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

