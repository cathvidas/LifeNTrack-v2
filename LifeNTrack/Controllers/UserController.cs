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
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        
    }
}