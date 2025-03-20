using System;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Frontend.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailSideBarSearchComponentPartial : ViewComponent
    {
        public _BlogDetailSideBarSearchComponentPartial()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}