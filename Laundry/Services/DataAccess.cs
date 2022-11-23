using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laundry.Models;
using Laundry.Controllers;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Laundry.Services
{
    public class DataAccess
    {

        LaundryManagmentSystemEntities db = new LaundryManagmentSystemEntities();

        public IEnumerable<Inventory> Get()
        {
            var result = db.Inventories.ToList();
            return result;
        }

        public Inventory Create(Inventory inventory)
        {
            var record = db.Inventories.Add(inventory);
            db.SaveChanges();
            return record;
        }

        public Inventory Edit(int id, Inventory inventory)
        {
            var result = db.Inventories.Find(id);
            result.Inventory_Type = inventory.Inventory_Type;
            db.SaveChanges();
            return result;

        }

       

    }
    }
