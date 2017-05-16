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
    public class skillApi : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Skill> Get()
        {

            var query = from c in db.skills
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            Skill query = (from c in db.skills
                        orderby c.id ascending
                        where c.id == id
                        select c).FirstOrDefault();
            return query;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Skill ski)
        {
            db.skills.Add(ski);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Skill ski)
        {
            var ass = db.skills.Where(c => c.id == ski.id).SingleOrDefault();
          ass.category = ski.category;
            ass.name = ski.name;

            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(Skill obj)
        {
            db.Remove(obj);
            db.SaveChanges();

        }
    }
}
