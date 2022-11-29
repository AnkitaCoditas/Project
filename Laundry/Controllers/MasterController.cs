using Laundry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Laundry.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Dashboard()
        {

            ViewBag.Message = "Welcome Admin";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
           
            using (var context = new LaundryManagmentSystemEntities4())
            {
                var result = context.Users.Where(model => model.UserName == user.UserName && model.Password == user.Password).FirstOrDefault();
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);

                    ViewBag.Message = "<script>alert('LOGIN SUCCESSFULL')</script>";
                    //Session["data"] = result.User_ID;
                    return RedirectToAction("Dashboard", "Master");


                }
                else
                {
                    ViewBag.Message = "<script>alert('Invalid Username and password')</script>";
                    return View();

                }
            }
        }
    }
}