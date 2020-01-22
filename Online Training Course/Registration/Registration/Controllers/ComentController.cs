using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class ComentController : Controller
    {
        // GET: Coment
        public ActionResult Coment()
        {
            Models.Database db = new Models.Database();
            db.DatabaseCon("RegData");
            db.setData("Insert into Comment(TuitorialName,FeedBack) values(" + "'"+Session["TopicName"].ToString()    +"'," + "'" + Request.Params["fedback"].ToString() + "'" + ")");
            return Redirect("~/StudentProfilePage/StudentProfilePage?a="+Session["Live"]);
        }
    }
}