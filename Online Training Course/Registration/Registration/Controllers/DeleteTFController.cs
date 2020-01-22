using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class DeleteTFController : Controller
    {
        // GET: DeleteTF
        public ActionResult DeleteTF()
        {
            Models.Database db = new Models.Database();
            db.DatabaseCon("RegData");
            db.setData("Delete from Comment where TuitorialName="+"'"+Request.Params["a"].ToString()   + "' and FeedBack="+"'"+Request.Params["b"].ToString()+"'");
            return Redirect("~/CommentSection/CommentSection");
        }
    }
}