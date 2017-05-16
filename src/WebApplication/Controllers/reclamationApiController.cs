using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class reclamationApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Reclamation> Get()
        {
            var query = from c in db.reclamations
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Reclamation> Get(int id)
        {

            var query = from c in db.reclamations
                        orderby c.id ascending
                        where c.id == id
                        select c;
            return query.ToList();

        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody]Reclamation rec)
        {
            db.reclamations.Add(rec);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Reclamation obj)
        {
            var ass = db.reclamations.Where(c => c.id == obj.id).SingleOrDefault();
            ass.state = obj.state;
            ass.description = obj.description;
          
            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Reclamation obj = db.reclamations.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}

