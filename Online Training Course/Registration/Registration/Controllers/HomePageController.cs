using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult HomePage()
        {
            return View();
        }
    }
}