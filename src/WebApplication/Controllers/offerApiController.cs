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
    public class offerApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Offer> Get()
        {
          
                var query = from c in db.offers
                            orderby c.id ascending
                            select c;
                return query.ToList();
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  Offer Get(int id)
        {

            Offer query = (from c in db.offers
                        orderby c.id ascending
                        where c.id == id
                        select c).FirstOrDefault();
            return query;
            
        }

        // POST api/values
        [HttpPost]
        
        public void Post([FromBody]Offer off)
        {
            db.offers.Add(off);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Offer obj)
        {
           var     ass = db.offers.Where(c => c.id == obj.id).SingleOrDefault();
            ass.title = obj.title;
            ass.typeOffer = obj.typeOffer;
            ass.description = obj.description;
            ass.dateStart = obj.dateStart;
            ass.dateEnd = obj.dateEnd;
            ass.salary = obj.salary;
                db.Entry(ass).State = EntityState.Modified;
                db.SaveChanges();
                     
        }

        // DELETE api/values/5
        [HttpDelete]
        
        public void Delete([FromBody]Offer obj)
        {
          //  Offer obj = db.offers.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}
