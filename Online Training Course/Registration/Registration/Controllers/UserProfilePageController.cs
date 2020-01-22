using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class UserProfilePageController : Controller
    {
        class getData : Models.Database
        {
            public ArrayList ListOfTopics = new ArrayList();

            public ArrayList FileName = new ArrayList();
            public ArrayList ViewFile = new ArrayList();

            public void TopicData(String Email)
            {
                DatabaseCon("RegData");
                getData("Select Topics from TeacherCourseTaken where Email='"+Email  +"'");
                while (reading.Read())
                {
                    ListOfTopics.Add(reading[0].ToString());
                }
            }
            public void Files(String Email)
            {
                DatabaseCon("RegData");
                getData("Select FileName from VideoTable where Email='"+Email  +"'");
                while (reading.Read())
                {
                    FileName.Add(reading[0].ToString());
                    String[] y = reading[0].ToString().Split('.');
                    String x = "";
                    for(int i = 1; i < y.Length; i++)
                    {
                        x += y[i];
                    }
                   
                    ViewFile.Add(x);

                }
            }
        }

        public String SelectTopic="";

        // GET: UserProfilePage
        public ActionResult UserProfilePage()
        {

            if (Session["UserProfile"] == null)
            {
                return Redirect("~/Login/Login");
            }

            Models.GetTopic gt = new Models.GetTopic();
            getData gd = new getData();
            gd.TopicData(Session["UserProfile"].ToString());
            gd.Files(Session["UserProfile"].ToString());

            gt.Topic = gd.ListOfTopics;
            gt.Files = gd.FileName;
            gt.ViewFile = gd.ViewFile;
            
           
            return View(gt);
        }

       

        [HttpPost]
        public ActionResult UserProfilePage(String SelectTopic,HttpPostedFileBase fileUploader)
        {
            this.SelectTopic = SelectTopic;
            String fileName="";
            if (fileUploader.ContentLength > 0)
            {
                fileName = Path.GetFileName(fileUploader.FileName);
                Models.VideoData vd = new Models.VideoData();
                fileName = vd.filter(fileName.ToString());
                var path = Path.Combine(Server.MapPath("~/Content/images/") + (Session["UserProfile"].ToString() + (fileName.ToString())));
                fileUploader.SaveAs(path);
            }
            Models.Database db = new Models.Database();
            db.DatabaseCon("RegData");
            db.setData("Insert into ApproveVideoTable(FileName,TopicName,Email) values("+"'"+ (Session["UserProfile"].ToString() + (fileName.ToString()))+"'," + "'" + this.SelectTopic + "'," + "'" + Session["UserProfile"].ToString() + "'" + ")");
            return Redirect("~/UserProfilePage/UserProfilePage");
        }
        public ActionResult LogOut()
        {
            Session["UserProfile"] = null;
            return Redirect("~/Login/Login");
        }

    }
}