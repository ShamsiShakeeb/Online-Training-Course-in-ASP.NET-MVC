using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class StudentLoginController : Controller
    {
        class getData : Models.Database
        {
            public Boolean login(String username, String pass)
            {
                DatabaseCon("RegData");
                getData("select Email, Password from StudentTable");
                while (reading.Read())
                {
                    if (reading[0].ToString().Equals(username) && reading[1].ToString().Equals(pass))
                    {
                        return true;
                    }


                }
                return false;
            }
        }
        // GET: StudentLogin
        public ActionResult StudentLogin(String username, String pass)
        {

            if (username != null && pass != null)
            {
                getData gd = new getData();



                if (gd.login(username, pass) == true)
                {
                    Session["StudentProfile"] = username;
                    return Redirect("~/StudentProfilePage/StudentProfilePage");
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