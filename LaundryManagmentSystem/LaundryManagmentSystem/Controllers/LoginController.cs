using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaundryManagmentSystem.Models;

namespace LaundryManagmentSystem.Controllers
{
    public class LoginController : Controller
    {

        LaundryManagmentSystemEntitiess db=new LaundryManagmentSystemEntitiess();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
           
        {
            var result = db.Users.Where(model => model.UserName == user.UserName && model.Password == user.Password).FirstOrDefault();

            if(result!=null)
            {
                ViewBag.Message = "<script>alert('LOGIN SUCCESSFULL')</script>";
                return RedirectToAction("Index", "Home");

               
            }
            else
            {
                ViewBag.Message = "<script>alert('UserName OR Password Is Incorrect!')</script>";
                return View();


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
            if (ModelState.IsValid == true)
            {
                db.Users.Add(usernew); 
                var result =db.SaveChanges();   
                if(result>0)
                {
                    ViewBag.InsertMessage= "<script>alert('REGISTERED SUCCESSFULLY')</script>";
                    ModelState.Clear();
                    
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('REGISTration failed')</script>";

                }
            }
            return View();
        }

    }
}