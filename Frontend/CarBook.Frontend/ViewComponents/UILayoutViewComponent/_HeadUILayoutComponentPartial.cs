using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents
{
	public class _HeadUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

