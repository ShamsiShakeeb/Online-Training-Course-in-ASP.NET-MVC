using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class CreateSectionController : Controller
    {
        // GET: CreateSection
        public ActionResult CreateSection(String NOT)
        {
            Models.Database db = new Models.Database();
            db.DatabaseCon("RegData");
            db.setData("Insert into TopicTable(TopicName) values(" + "'" + NOT + "'" + ")");
            return View();
        }
    }
}