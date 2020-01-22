using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class DataVisualizationController : Controller
    {

        class getNewTopic : Models.Database
        {
            public HashSet<String> hs = new HashSet<String>();
            


            public void Topic()
            {
                DatabaseCon("RegData");
                getData("Select * from VisualRepesentation");
                while (reading.Read())
                {
                    hs.Add(reading[0].ToString().ToUpper());
                    
                }
            }
           public ArrayList TopicName = new ArrayList();
           public  ArrayList TopicFrequncy = new ArrayList();
           public String x = "";
            public void getFrequency(HashSet<String> hs)
            {
                String[] ob = hs.ToArray();
                for(int i = 0; i < hs.Count; i++)
                {
                    DatabaseCon("RegData");
                    getData("SELECT Count(Data) from VisualRepesentation where Data='"+ob[i]+"'");

                    while (reading.Read())
                    {
                        if (i != hs.Count - 1) 
                            x += "{ y: " + reading[0].ToString() + ", label: " + "" + "'" + ob[i] + "'"+ "" + " },";
                        else
                        {
                            x += "{ y: " + reading[0].ToString() + ", label: " + "" + "'" + ob[i] + "'" + " }";

                        }
                        break;
                    }
                  //  TopicName.Add(ob[i]);
                  //  TopicFrequncy.Add(reading[0].ToString());
                }
            }
        }
        // GET: DataVisualization
        public ActionResult DataVisualization()
        {

            getNewTopic gtn = new getNewTopic();
            gtn.Topic();
            gtn.getFrequency(gtn.hs);
            Models.DataVisualization dv = new Models.DataVisualization();
            dv.TopicName = gtn.TopicName;
            dv.TopicFreq = gtn.TopicFrequncy;
            dv.Result = (gtn.x);
            

           

            return View(dv);
        }
    }
}