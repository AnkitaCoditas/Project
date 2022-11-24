using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laundry.Models;
using Laundry.Services;


namespace Laundry.Controllers
{

    public class LaundryCategoryController : Controller
    {
        LaundryCategoryDataAccess dataaccess = new LaundryCategoryDataAccess();

        // GET: Inventory
        public ActionResult Index()
        {

            var result = dataaccess.Get();
            return View(result);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Laundry_Category laundry)
        {

            dataaccess.Create(laundry);
            return RedirectToAction("Index", "Laundry_Category");

        }





        public ActionResult Delete(int id)
        {
            dataaccess.Delete(id);
            return RedirectToAction("Index", "Laundry_Category");

        }





    }
}
