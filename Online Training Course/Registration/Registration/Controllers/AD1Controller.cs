using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class AD1Controller : Controller
    {
        // GET: AD1
        public ActionResult AD1()
        {
            Models.Content c = new Models.Content();
            if (Request.Params["a"].ToString().Equals("View"))
            {
                c.File =  Request.Params["File"].ToString();
                return View(c);
            }
            else if (Request.Params["a"].ToString().Equals("Approve"))
            {
                Models.Database db = new Models.Database();
                db.DatabaseCon("RegData");
                db.setData("Insert into VideoTable(FileName,TopicName,Email) values("+"'"+Request.Params["File"].ToString()  +"'," + "'" + Request.Params["Topic"].ToString() + "'," + "'" + Request.Params["Email"].ToString() + "'" + ")");
                db.DatabaseCon("RegData");
                db.setData("Delete from ApproveVideoTable where Email=" + "'" + Request.Params["Email"].ToString() + "' and FileName=" + "'" + Request.Params["File"].ToString() + "'");
                return Redirect("~/ListOfVideo/ListOfVideo");
            }
            else
            {
                Models.Database db = new Models.Database();
                db.DatabaseCon("RegData");
                db.setData("Delete from ApproveVideoTable where Email=" + "'" + Request.Params["Email"].ToString() + "' and FileName=" + "'"+Request.Params["File"].ToString() + "'");
                return Redirect("~/ListOfVideo/ListOfVideo");
            }
           
            
        }
    }
}