using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
	public class _BlogDetailCreateCommentComponentPartial : ViewComponent
	{

		public _BlogDetailCreateCommentComponentPartial()
		{
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

