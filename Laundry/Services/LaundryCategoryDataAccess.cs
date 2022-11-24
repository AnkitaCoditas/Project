using Laundry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry.Services
{
    public class LaundryCategoryDataAccess
    {
        LaundryManagmentSystemEntities db = new LaundryManagmentSystemEntities();

        public IEnumerable<Laundry_Category> Get()
        {
            var result = db.Laundry_Category.ToList();
            return result;
        }
        public Laundry_Category Create(Laundry_Category laundry)
        {
            var res = db.Laundry_Category.Add(laundry);
            db.SaveChanges();
            return res;
        }

        public Laundry_Category Delete(int id)
        {
            var record = db.Laundry_Category.Where(x => x.Laundry_ID == id).First();
            db.Laundry_Category.Remove(record);
            db.SaveChanges();
            return record;

        }
    }
}