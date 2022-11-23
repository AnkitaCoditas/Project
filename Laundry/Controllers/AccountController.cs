using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laundry.Models;
using System.Web.Security;

namespace Laundry.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var context = new LaundryManagmentSystemEntities())
            {
                var result = context.Users.Where(model => model.UserName == user.UserName && model.Password == user.Password).FirstOrDefault();

                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName,false);
                     ViewBag.Message = "<script>alert('LOGIN SUCCESSFULL')</script>";
                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    ViewBag.Message = "<script>alert('Invalid Username and password')</script>";
                    return View();

                }
            }

                
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var usernew = user;
            usernew.Role_ID = 1;
            using (var context = new LaundryManagmentSystemEntities())
            {
                context.Users.Add(usernew);
                context.SaveChanges();
            }
                return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}