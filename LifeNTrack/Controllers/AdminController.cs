using LifeNTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class AdminController : BaseController
    {
        User user = new User();

        private activityDBEntities fe = new activityDBEntities();


        public ActionResult Index()
        {
            var userList = (from a in fe.Users
                            where a.RoleID == 2
                            select a).ToList();

            ViewData["UserList"] = userList;
          

            return View();
        }


        public ActionResult Announcement()
        {
            var announcementList = (from a in fe.Announcements
                            select a).ToList();

            ViewData["AnnouncementList"] = announcementList;
            return View();
        }
        public ActionResult UsersList()
        {
            var userList = (from a in fe.Users
                            where a.RoleID == 2
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }

        public ActionResult SetUserStatus(FormCollection fc)
        {
            int userId = int.Parse(fc["userID"]);
            String status = fc["status"];
            User u = (from a in fe.Users where a.UserID == userId select a).FirstOrDefault();
            u.Status = status;
            fe.SaveChanges();
            return RedirectToAction("UsersList", "Admin");
        }

        public ActionResult AddAnnouncement(FormCollection fc)
        {
            String title = fc["Title"];
            String message = fc["Message"];
            Announcement an = new Announcement();
            an.Title = title;
            an.Message = message;
            fe.Announcements.Add(an);
            fe.SaveChanges();

        
            return RedirectToAction("Announcement");
        }
    }
}