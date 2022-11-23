using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laundry.Models;

namespace Laundry.Controllers
{
    public class CategoryController : Controller
    {

        LaundryManagmentSystemEntities context = new LaundryManagmentSystemEntities();

        // GET: Category
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
            var result=context.Laundry_Category.Add(category);
            return View(result);
            }





        



    }
}