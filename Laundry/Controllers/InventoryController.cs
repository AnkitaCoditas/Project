using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laundry.Models;
using Laundry.Services;


namespace Laundry.Controllers
{

    public class InventoryController : Controller
    {
        LaundryManagmentSystemEntities context = new LaundryManagmentSystemEntities();

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Get()
        {
            var result = context.Inventories.ToList();
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(Inventory inventory)
        {
            var record = context.Inventories.Add(inventory);
            context.SaveChanges();
            return RedirectToAction("Get", "Inventory");
        }

        public ActionResult Edit(int id)
        {
            var newrecord = context.Inventories.Find(id);
            return View(newrecord);
        }
        
        public ActionResult Edit(int id, Inventory inventory)
        {
            var result = context.Inventories.Find(id);
            result.Inventory_Type = inventory.Inventory_Type;
            context.SaveChanges();
            return RedirectToAction("Get");
        }

        
    }
}
