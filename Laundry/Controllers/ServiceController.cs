using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laundry.Model;
using Laundry.Services;


namespace Laundry.Controllers
{

    public class ServiceController : Controller
    {
        ServiceDataAccess dataaccess = new ServiceDataAccess();

        LaundryManagmentSystemEntities2 context = new LaundryManagmentSystemEntities2();


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
        public ActionResult Create(Service service)
        {


            dataaccess.Create(service);
            Session["data"] = service.Services_ID;



            return RedirectToAction("Index", "Service");

        }





        public ActionResult Delete(int id)
        {
            var record = dataaccess.Delete(id);
            return RedirectToAction("Index", "Service");

        }






    }
}
