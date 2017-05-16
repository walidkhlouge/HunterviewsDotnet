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
    public class formationApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Formation> Get()
        {
            var query = from c in db.formations
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Formation> Get(int id)
        {

            var query = from c in db.formations
                        orderby c.id ascending
                        where c.id == id
                        select c;
            return query.ToList();

        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody]Formation off)
        {
            db.formations.Add(off);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Formation obj)
        {
            var ass = db.formations.Where(c => c.id == obj.id).SingleOrDefault();
           
            ass.dateStart = obj.dateStart;
            ass.dateEnd = obj.dateEnd;
            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Formation obj = db.formations.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}
