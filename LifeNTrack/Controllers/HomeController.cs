using LifeNTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["FirstName"];
            String lastName = fc["LastName"];
            String email = fc["Email"];
            String password = fc["Password"];

            User use = new User();
            use.FirstName = firstName;
            use.LastName = lastName;
            use.Email = email;
            use.Password = password;
            use.RoleID = 1;

            activityDBEntities fe = new activityDBEntities();
            fe.Users.Add(use);
            fe.SaveChanges();

            int newUserID = use.UserID;
            Session["UserID"] = newUserID;
            Session["UserRole"] = 1;

            return RedirectToAction("Index", "User");
        }

        public ActionResult redirectToDashboard(FormCollection fc)
        {
            String email = fc["Email"];
            String password = fc["Password"];


            activityDBEntities rdbe = new activityDBEntities();
            User u = (from a in rdbe.Users
                      where a.Email == email && a.Password == password
                      select a).FirstOrDefault();

            if (u != null)
            {
                Session["UserID"] = u.UserID; 
                Session["UserRole"] = u.RoleID;
                if (u.RoleID == 2)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (u.RoleID == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
                return RedirectToAction("Index");
           
        }
        

       

    }
}