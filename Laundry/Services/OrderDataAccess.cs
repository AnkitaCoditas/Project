using Laundry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry.Services
{
    public class OrderDataAccess
    {
        LaundryManagmentSystemEntities2 db = new LaundryManagmentSystemEntities2();

        public IEnumerable<Order> Get()
        {
            var result = db.Orders.ToList();

            return result;
        }

        public Order Create(Order order)
        {
            
            var res = db.Orders.Add(order);
            db.SaveChanges();
            return res;
        }

        public Order Delete(int id)
        {
            var res = db.Orders.Where(x => x.Order_ID == id).First();
            db.Orders.Remove(res);
            db.SaveChanges();

            return res;

        }

    }
}