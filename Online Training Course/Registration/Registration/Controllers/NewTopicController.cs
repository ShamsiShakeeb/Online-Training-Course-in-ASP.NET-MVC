using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class NewTopicController : Controller
    {
        // GET: NewTopic
        public ActionResult NewTopic()
        {
            Models.Database db = new Models.Database();
            db.DatabaseCon("RegData");
            db.setData("Insert into VisualRepesentation(Data) values("+"'"+Request.Params["value"].ToString().ToUpper()   +"'" + ")");
            return Redirect("~/CommentSection/CommentSection");
        }
    }
}