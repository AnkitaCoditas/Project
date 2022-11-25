using Laundry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry.Services
{
    
        public class ServiceDataAccess
        {
            LaundryManagmentSystemEntities2 db = new LaundryManagmentSystemEntities2();

            public IEnumerable<Service> Get()
            {
                var result = db.Services.ToList();

                return result;
            }

            public Service Create(Service service)
            {
                var res = db.Services.Add(service);
                db.SaveChanges();
                return res;
            }

            public Service Delete(int id)
            {
                var res = db.Services.Where(x => x.Services_ID == id).First();
                db.Services.Remove(res);
                db.SaveChanges();

                return res;

            }

        }
    }

