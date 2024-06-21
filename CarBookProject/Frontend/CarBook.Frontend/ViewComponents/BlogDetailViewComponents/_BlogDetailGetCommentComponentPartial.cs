using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailGetCommentComponentPartial : ViewComponent
	{
		public _BlogDetailGetCommentComponentPartial()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}

