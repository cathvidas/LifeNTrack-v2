using LifeNTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class UserController : BaseController
    {
        User user = new User();

        private activityDBEntities fe = new activityDBEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Friends()
        {
            return View();
        }
        public ActionResult Timeline()
        {
            return View();
        }
        public ActionResult Announcements()
        {
            var announcementList = (from a in fe.Announcements
                                    select a).ToList();

            ViewData["AnnouncementList"] = announcementList;
            return View();
        }
        public ActionResult Events()
        {
            var userId = Session["UserID"] as int?;
            var ac = (from a in fe.Activities where a.UserID == userId select a).ToList();
            ViewData["ActivityList"] = ac;
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult AddActivity(FormCollection fc)
        {
            String title = fc["title"];
            DateTime date = (DateTime.Parse(fc["date"])).Date;
            TimeSpan time = TimeSpan.Parse(fc["time"]);
            String address = fc["address"];
            String desc = fc["description"];
            String ootd = fc["ootd"];
            var userId = Session["UserID"] as int?;

            Activity a = new Activity();
            a.ActTitle = title;
            a.ActDate = date;
            a.ActTime = time;
            a.ActLocation = address;
            a.ActOOTD = ootd;
            a.ActDescription = desc;
            a.ActRemark = "upcoming";
            a.UserID = userId;
            a.ActCreated = DateTime.Now;
            
            fe.Activities.Add(a);
            fe.SaveChanges();

            return RedirectToAction("Events", "User");
        }
        public ActionResult UpdateActivity(FormCollection fc)
        {
            int actId = int.Parse(fc["activityId"]);
            String title = fc["title"];
            DateTime date = (DateTime.Parse(fc["date"])).Date;
            TimeSpan time = TimeSpan.Parse(fc["time"]);
            String address = fc["address"];
            String desc = fc["description"];
            String ootd = fc["ootd"];


            Activity ac = (from b in fe.Activities where b.ActivityID == actId select b).FirstOrDefault();
          
            ac.ActTitle = title;
            ac.ActDate = date;
            ac.ActTime = time;
            ac.ActLocation = address;
            ac.ActOOTD = ootd;
            ac.ActDescription = desc;
            
            fe.SaveChanges();

            return RedirectToAction("Events", "User");
        }

        public ActionResult DeleteActivity(FormCollection fc)
        {
            int actId = int.Parse(fc["activityId"]);

            Activity ac = (from b in fe.Activities where b.ActivityID == actId select b).FirstOrDefault();
            fe.Activities.Remove(ac);
            fe.SaveChanges();
            
            return RedirectToAction("Events");
        }
        public ActionResult SetActivityStatus(FormCollection fc)
        {
            int actId = int.Parse(fc["activityId"]);
            String remark = fc["remark"];
            Activity ac = (from b in fe.Activities where b.ActivityID == actId select b).FirstOrDefault();
            ac.ActRemark = remark;
            fe.SaveChanges();
            return RedirectToAction("Events");
        }

    }
}