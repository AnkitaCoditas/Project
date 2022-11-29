using Laundry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry.Repository
{
    public class OrderDataAccess
    {
        LaundryManagmentSystemEntities4 db = new LaundryManagmentSystemEntities4();

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



        //public Order Edit(int Id, Order order)
        //{
        //    var record = db.Orders.Find(Id);
        //    record.Laundry_ID = order.Laundry_ID;
        //    record.Services_ID= order.Services_ID;  

        //    db.SaveChanges();
        //    return record;
        //}

        public Order Edit(int Id,Order order)
        {
            var data = db.Orders.Where(x => x.Order_ID == Id).FirstOrDefault();
            if (data != null)
            {
                
                data.Inventory_ID =order.Inventory_ID;
                data.Services_ID = order.Services_ID;
                data.Laundry_ID = order.Laundry_ID;
                data.Quantity = order.Quantity;

                db.SaveChanges();
                return data;

            }
            else
                return null;    
            

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