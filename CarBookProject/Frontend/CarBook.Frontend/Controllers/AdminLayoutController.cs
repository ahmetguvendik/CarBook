using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Frontend.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavBar()
        {
            return PartialView();
        }

         public PartialViewResult AdminLayoutSideBar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutScript()
        {
            return PartialView();
        }
    }
}

