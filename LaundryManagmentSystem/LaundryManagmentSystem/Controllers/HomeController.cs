using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaundryManagmentSystem.Models;
namespace LaundryManagmentSystem.Controllers
{
    
    public class HomeController : Controller
    {
        LaundryManagmentSystemEntitiess db = new LaundryManagmentSystemEntitiess();


        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Laundry_Category category)
        {
            db.Laundry_Category.Add(category);
            db.SaveChanges();
            ViewBag.message = "Category Added Successfully";
            return View();


        }




        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}