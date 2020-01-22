using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class ADController : Controller
    {
        // GET: AD
        public ActionResult AD()
        {

            String x = Request.Params["a"];

            if (x.Equals("Approve"))
            {
                Models.Database db = new Models.Database();
                db.DatabaseCon("RegData");
                db.setData("Insert into ApproveTable(Username,Phone,Email,Password) values(" +"'"+Request.Params["b"].ToString()   +"'," + "'" + Request.Params["c"].ToString() + "'," + "'" + Request.Params["d"].ToString() + "'," + "'" + Request.Params["e"].ToString() + "'" + ")");
                db.setData("Delete from reg where Email='" + Request.Params["d"].ToString() + "'");
            }
            else
            {
                Models.Database db = new Models.Database();
                db.DatabaseCon("RegData");
                db.setData("Delete from reg where Email='" +Request.Params["b"].ToString()+ "'");

            }


            return Redirect("~/AdminPage/AdminPage");
        }
    }
}