using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class CourseTakenController : Controller
    {

         class getTopic : Models.Database
        {
            public ArrayList listOfTopic = new ArrayList();

            public void getTopics()
            {

                DatabaseCon("RegData");
                getData("Select * from TopicTable");
                while (reading.Read())
                {
                    if (!reading[0].ToString().Equals(""))
                    {
                        listOfTopic.Add(reading[0].ToString());
                    }
                }

            }
        }
        public String DatabaseTable = "";
        // GET: CourseTaken
        public ActionResult CourseTaken()
        {
            if (Session["StudentProfile"] == null && Session["UserProfile"]==null)
            {
                
                return Redirect("~/HomePage/HomePage");
            }
            

            Models.GetTopic gt = new Models.GetTopic();
            getTopic gd = new getTopic();
            gd.getTopics();
            gt.Topic = gd.listOfTopic;
            Session["DataTable"] = Request.Params["b"].ToString();
            Session["EmailTable"] = Request.Params["a"].ToString();


            return View(gt);
        }
        public ActionResult StudentTakenCourse(String Topic)
        {
           
                Models.Database db = new Models.Database();
                db.DatabaseCon("RegData");
                db.setData("Insert into "+ Session["DataTable"].ToString()+" (Email,Topics) values(" + "'"+Session["EmailTable"].ToString()   +"'," + "'" + Topic + "'" + ")");
                if(Session["DataTable"].ToString().Equals("StudentCourseTaken"))
                return Redirect("~/StudentProfilePage/StudentProfilePage");
            else
            {
                return Redirect("~/UserProfilePage/UserProfilePage");
            }
            
        }
    }
}