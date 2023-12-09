using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class UserController : Controller
    {
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