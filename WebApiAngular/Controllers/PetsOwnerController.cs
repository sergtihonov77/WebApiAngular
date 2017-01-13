using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngular.Models;

namespace WebApiAngular.Controllers
{
    public class PetsOwnerController : ApiController
    {
        public PetsDB db = new PetsDB();

        private int pageSize = 3;
        // GET api/values
        public List<PetsOwners> Get()
        {
            var petsowners = db.PetsOwners.ToList();       
            return petsowners;
        }

        // GET api/values/5
        public PetsOwners Get(int id)
        {
            if (id != 0)
            {
                return db.PetsOwners.FirstOrDefault(ow => ow.Id == id);
            }
            else return null;
        }

        // POST api/values
        public void Post([FromBody]PetsOwners value)
        {
            if (value != null)
            {
                value.Count = 0;
                if (ModelState.IsValid)
                {
                    db.PetsOwners.Add(value);
                    db.SaveChanges();
                }
            }      
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]PetsOwners value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var model = db.PetsOwners.FirstOrDefault(ow => ow.Id == id);
            if (model != null)
            {
                var rem = db.Pets.Where(p => p.OwnerId == id).ToList();
                if (rem != null)
                {
                    db.Pets.RemoveRange(rem);
                    db.SaveChanges();
                }
                db.PetsOwners.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
