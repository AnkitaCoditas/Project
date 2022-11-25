using Laundry.Model;
using Laundry.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laundry.Controllers
{
    public class OrderController : Controller
    {
        OrderDataAccess dataaccess = new OrderDataAccess();
        Inventory inventory = new Inventory();
        InventoryDataAccess dataaccess1 = new InventoryDataAccess();
        LaundryCategoryDataAccess categorydataaccess = new LaundryCategoryDataAccess(); 
        LaundryManagmentSystemEntities2 context = new LaundryManagmentSystemEntities2();


        // GET: Inventory
        public ActionResult Index()
        {

            var result = dataaccess.Get();
            return View(result);
        }



        public ActionResult Create()
        {
            List<Laundry_Category> laundry_Categories = new List<Laundry_Category>();
            var categoryresult = categorydataaccess.Get();
            foreach(var category in categoryresult)
            {
                laundry_Categories.Add(category);   
            }
            ViewBag.laundry_Categories = laundry_Categories;
             



            List<Inventory> InventoryItem = new List<Inventory>();
            // Add Data from "categories" to "categoryItem"

            var result = dataaccess1.Get();
            foreach (var r in result)
            {
                InventoryItem.Add(r);
            }
            ViewBag.InventoryItem = InventoryItem;
             
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {

            order.User_ID = Convert.ToInt32(Session["data"]);
            order.Services_ID = Convert.ToInt32(Session["data"]);


            dataaccess.Create(order);

            return RedirectToAction("Index", "Order");

        }





        public ActionResult Delete(int id)
        {
            var record = dataaccess.Delete(id);
            return RedirectToAction("Index", "Order");

        }

    }
}


    