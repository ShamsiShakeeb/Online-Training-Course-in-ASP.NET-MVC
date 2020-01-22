using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class StudentRegistrationController : Controller
    {
        // GET: StudentRegistration
        public ActionResult StudentRegistration(String Username, String phone, String email, String psw, String psw_repeat, String info)
        {
            Models.Reg r = new Models.Reg();

            r.Username = Username;
            r.phone = phone;
            r.email = email;
            r.psw = psw;
            r.psw_repeat = psw_repeat;

            Models.Database dbc = new Models.Database();


            try
            {

                if ((Username) == null || phone == null || email == null || (psw) == null)
                {
                    return View();
                }
                else
                {

                    if (info.Equals("t") && psw.Equals(psw_repeat))
                    {
                        
                            dbc.DatabaseCon("RegData");
                            dbc.setData("Insert into StudentTable(Username, Phone, Email, Password) values(" + "'" + r.Username + "'," + "'" + r.phone + "'," + "'" + r.email + "'," + "'" + r.psw + "'" + ")");
                      
                    }
                    return View(r);
                }
            }
            catch (Exception e)
            {
                r.psw_repeat = e.ToString();
                return View(r);
            }
          //  return View();
        }
    }
}