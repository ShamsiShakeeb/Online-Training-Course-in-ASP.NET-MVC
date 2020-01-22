using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class ListOfVideoController : Controller
    {

        class getData : Models.Database
        {
            public ArrayList Email = new ArrayList();
            public ArrayList Topic = new ArrayList();
            public ArrayList File = new ArrayList();

            public void Data()
            {
                DatabaseCon("RegData");
                getData("Select * from ApproveVideoTable");
                while (reading.Read())
                {
                    File.Add(reading[0].ToString());
                    Topic.Add(reading[1].ToString());
                    Email.Add(reading[2].ToString());
                }
            }
        }
        // GET: ListOfVideo
        public ActionResult ListOfVideo()
        {
            getData gd = new getData();
            gd.Data();
            Models.VideoData vd = new Models.VideoData();
            vd.Email = gd.Email;
            vd.Topic = gd.Topic;
            vd.File = gd.File;
            return View(vd);
        }
    }
}