using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiAngular.Models;

namespace WebApiAngular.Controllers
{
    public class PetsController : ApiController
    {
        public PetsDB db = new PetsDB();
        // GET: api/Pets
        public List<Pets> Get()
        {
            return db.Pets.ToList();
        }

        // GET: api/Pets/5
        public List<Pets> Get(int id)
        {
            if (id != 0)
            {
                var res = db.Pets.Where(p => p.OwnerId == id).ToList();
                return res;
            }
            else return null;
        }

        // POST: api/Pets
        public void Post([FromBody]Pets value)
        {
            if (value != null)
            {
                var owner = db.PetsOwners.FirstOrDefault(ow => ow.Id == value.OwnerId);
                if (owner != null)
                {
                    owner.Count = owner.Count + 1;
                    value.OwnerId = owner.Id;
                    db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
                    db.Pets.Add(value);
                    db.SaveChanges();
                }
            }
        }

        // PUT: api/Pets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pets/5
        public void Delete(int id)
        {
            if (id != 0)
            {
                var model = db.Pets.FirstOrDefault(p => p.Id == id);
                if (model != null)
                {
                    var owner = db.PetsOwners.FirstOrDefault(o => o.Id == model.OwnerId);
                    owner.Count = owner.Count - 1;
                    db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
                    db.Pets.Remove(model);
                    db.SaveChanges();
                }
            }
        }
    }
}
