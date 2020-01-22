using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class CommentSectionController : Controller
    {
        class getComment : Models.Database
        {
           public ArrayList TuitorialName = new ArrayList();
           public ArrayList FeedBack = new ArrayList();
            public void getCom()
            {
                DatabaseCon("RegData");
                getData("Select * from Comment");
                while (reading.Read())
                {
                    TuitorialName.Add(reading[0].ToString());
                    FeedBack.Add(reading[1].ToString());
                }
            }
        }
        class getStudentList : Models.Database
        {
            public ArrayList Name = new ArrayList();
            public ArrayList email = new ArrayList();
            public ArrayList phone = new ArrayList();

            public void getStuList(String Table)
            {
                DatabaseCon("RegData");
                getData("Select Username,Phone,Email FROM "+Table);
                while (reading.Read())
                {
                    Name.Add(reading[0].ToString());
                    email.Add(reading[1].ToString());
                    phone.Add(reading[2].ToString());
                }
            }
        }
        // GET: CommentSection
        public ActionResult CommentSection()
        {

            getComment gt = new getComment();
            Models.CommentModel cm = new Models.CommentModel();
            gt.getCom();
            cm.TuitorialName = gt.TuitorialName;
            cm.FeedBack = gt.FeedBack;

            return View(cm);
        }

        public ActionResult StudentList()
        {
            Models.UserList stu = new Models.UserList();
            getStudentList list = new getStudentList();
            list.getStuList("StudentTable");
            stu.Name = list.Name;
            stu.email = list.email;
            stu.phone = list.phone;
            return View(stu);
        }
        public ActionResult TeacherList()
        {
            Models.UserList stu = new Models.UserList();
            getStudentList list = new getStudentList();
            list.getStuList("ApproveTable");
            stu.Name = list.Name;
            stu.email = list.email;
            stu.phone = list.phone;
            return View(stu);
           
        }
    }
}