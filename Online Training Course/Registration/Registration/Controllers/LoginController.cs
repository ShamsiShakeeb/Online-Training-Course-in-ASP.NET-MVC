using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class LoginController : Controller
    {
        class getData: Models.Database
        {
            public Boolean login(String username, String pass)
            {
                DatabaseCon("RegData");
                getData("select Email, Password from ApproveTable");
                while (reading.Read())
                {
                    if(reading[0].ToString().Equals(username) && reading[1].ToString().Equals(pass))
                    {
                        return true;
                    }
                    

                }
                return false;
            }
        }
        // GET: Login
        public ActionResult Login(String username, String pass)
        {
            if (username != null && pass != null)
            {
                getData gd = new getData();



                if (gd.login(username, pass) == true)
                {
                    Session["UserProfile"] = username;
                    return Redirect("~/UserProfilePage/UserProfilePage");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
           // return View();
        }
    }
}