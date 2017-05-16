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
    public class evaluationApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Evaluation> Get()
        {

            var query = from c in db.evaluations
                        orderby c.id ascending
                        select c;
            return query.ToList();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Evaluation Get(int id)
        {

            Evaluation query = (from c in db.evaluations
                        orderby c.id ascending
                        where c.id == id
                        select c).FirstOrDefault();
            return query;

        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody]Evaluation eval)
        {
            db.evaluations.Add(eval);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Evaluation obj)
        {
            var ass = db.evaluations.Where(c => c.id == obj.id).SingleOrDefault();
            ass.date = obj.date;
            ass.mark = obj.mark;
            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(Evaluation obj)
        {
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}
