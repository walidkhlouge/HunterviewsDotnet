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
    public class certificationApiController : DefaultController
    
        {
            // GET: api/values
            [HttpGet]
            public IEnumerable<Certification> Get()
            {

                var query = from c in db.certifications
                            orderby c.id ascending
                            select c;
                return query.ToList();

            }

            // GET api/values/5
            [HttpGet("{id}")]
            public Certification Get(int id)
            {

                var query = (from c in db.certifications
                            orderby c.id ascending
                            where c.id == id
                            select c).FirstOrDefault();
                return query;

            }

            // POST api/values
            [HttpPost]

            public void Post([FromBody]Certification certif)
            {
                db.certifications.Add(certif);
                db.SaveChanges();

            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]Certification obj)
            {
                var ass = db.certifications.Where(c => c.id == obj.id).SingleOrDefault();
                ass.title = obj.title;
                
                ass.dateStart = obj.dateStart;
                ass.dateEnd = obj.dateEnd;
                db.Entry(ass).State = EntityState.Modified;
                db.SaveChanges();

            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                Certification obj = db.certifications.Where(c => c.id == id).SingleOrDefault();
                db.Remove(obj);
                db.SaveChanges();
            }
        }
    }


