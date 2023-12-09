using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Announcement()
        {
            return View();
        }
        public ActionResult UsersList()
        {
            return View();
        }
    }
}