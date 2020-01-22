using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult AdminLogin(String username,String pass)
        {
            if(username!=null && pass != null)
            {
                if(username.Equals("Admin") && pass.Equals("Admin"))
                {
                    Session["Admin"] = "LoginConfirmed";
                    return Redirect("~/AdminPage/AdminPage");
                }
            }
            return View();
        }
    }
}