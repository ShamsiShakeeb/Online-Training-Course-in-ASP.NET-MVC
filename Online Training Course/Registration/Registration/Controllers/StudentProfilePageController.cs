using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class StudentProfilePageController : Controller
    {

        class getData : Models.Database
        {
           public ArrayList FileName = new ArrayList();
           public   ArrayList ViewFile = new ArrayList();
            public ArrayList Topic = new ArrayList();

            public void getDat(String Topic)
            {
                DatabaseCon("RegData");
                getData("Select FileName from VideoTable where TopicName="+"'"+Topic   +"'");
                while (reading.Read())
                {
                    FileName.Add(reading[0].ToString());
                    String[] y = reading[0].ToString().Split('.');
                    String x = "";
                    for (int i = 1; i < y.Length; i++)
                    {
                        x += y[i];
                    }

                    ViewFile.Add(x);

                }
            }
            public void getTopic(String Email)
            {
                
                DatabaseCon("RegData");
                getData("Select Topics from StudentCourseTaken where Email="+"'"+Email+"'");
               
                while (reading.Read())
                {
                    Topic.Add(reading[0].ToString());
                }
            }
           
        }
        // GET: StudentProfilePage
        public ActionResult StudentProfilePage(String Topic)
        {
            if(Session["StudentProfile"] == null)
            {
                return Redirect("~/StudentLogin/StudentLogin");
            }
            String urlTopic = "";

            try
            {
                urlTopic = Request.Params["a"];
                char[] a = urlTopic.ToCharArray();
                int count = 0;
                for(int i = 0; i < a.Length; i++)
                {
                    if(a[i]=='.' && a[i+1]=='c' && a[i+2]=='o' && a[i + 3] == 'm')
                    {
                        count = i + 3;
                        break;
                    }
                }

                urlTopic = urlTopic.Substring(count+1);
                String[] set = urlTopic.Split('.');
                String union = "";
                for(int i = 0; i < set.Length; i++)
                {
                    union += set[i];
                }
                urlTopic = union;
                

            }
            catch(Exception e)
            {

            }


            Models.GetTopic gt = new Models.GetTopic();
            getData gd = new getData();
            gd.getTopic(Session["StudentProfile"].ToString());
           
            gt.Topic = gd.Topic;
            gt.TopicName = urlTopic;
            if(Topic!=null)
            gt.Topics = Topic;

            if (Topic != null)
            {
               
                gd.getDat(Topic);
               
                gt.ViewFile = gd.ViewFile;
                gt.Files = gd.FileName;
            }




            return View(gt);

        }
        public ActionResult LogOut()
        {
            Session["StudentProfile"] = null;
            return Redirect("~/StudentLogin/StudentLogin");
        }
    }
}