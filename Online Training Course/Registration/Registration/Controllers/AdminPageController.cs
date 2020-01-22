using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class AdminPageController : Controller
    {

        class AllUser : Models.Database
        {
            public ArrayList Username = new ArrayList();
            public ArrayList Phone = new ArrayList();
            public ArrayList Email = new ArrayList();
            public ArrayList pass = new ArrayList();

            public void Users()
            {
                DatabaseCon("RegData");
                getData("Select Username,Phone,Email,Password from reg");

                while (reading.Read())
                {
                    Username.Add(reading[0].ToString());
                    Phone.Add(reading[1].ToString());
                    Email.Add(reading[2].ToString());
                    pass.Add(reading[3].ToString());
                }
            }
        }

        // GET: AdminPage
        public ActionResult AdminPage()
        {

            if (Session["Admin"] != null)
            {

                AllUser allu = new AllUser();
                allu.Users();
                Models.Admin ad = new Models.Admin();

                ad.Username = allu.Username;
                ad.Phone = allu.Phone;
                ad.Email = allu.Email;
                ad.pass = allu.pass;

                return View(ad);
            }
            else
            {
                return Redirect("~/AdminLogin/AdminLogin");
            }
        }
    }
}