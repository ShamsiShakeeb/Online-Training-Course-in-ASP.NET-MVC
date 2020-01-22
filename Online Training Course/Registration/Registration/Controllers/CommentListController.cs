using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class CommentListController : Controller
    {
        class getData : Models.Database { 

        public ArrayList cmntList = new ArrayList();
            public void getComment(String Topic)
            {

                DatabaseCon("RegData");
                getData("Select FeedBack from Comment where TuitorialName='" + Topic + "'");
                while (reading.Read())
                {
                    cmntList.Add(reading[0].ToString());
                }
            }
        }
        // GET: CommentList
        public ActionResult Comment()
        {
            if (Session["StudentProfile"] == null)
            {
                return Redirect("~/StudentLogin/StudentLogin");
            }
            getData gd = new getData();
            gd.getComment(Request.Params["a"].ToString());
            Models.GetTopic gt = new Models.GetTopic();
            gt.cmnt = gd.cmntList;
            return View(gt);
        }
    }
}