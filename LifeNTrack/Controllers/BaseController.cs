using LifeNTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeNTrack.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            var userId = Session["UserID"] as int?;

            if (userId.HasValue)
            {
                using (var dbContext = new activityDBEntities())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId.Value);

                    if (user != null)
                    {
                        ViewData["UserName"] = user.FirstName;
                        var ac = (from a in dbContext.Activities where a.UserID == userId select a).ToList();
                        ViewData["ActivityList"] = ac;
                    }

                }


            }
        }
    }
}