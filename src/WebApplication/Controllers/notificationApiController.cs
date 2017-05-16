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
    public class notificationApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            var query = from c in db.notifications
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Notification Get(int id)
        {

            Notification query = (from c in db.notifications
                        orderby c.id ascending
                        where c.id == id
                        select c).FirstOrDefault();
            return query;

        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody]Notification notif)
        {
            db.notifications.Add(notif);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Notification obj)
        {
            var ass = db.notifications.Where(c => c.id == obj.id).SingleOrDefault();
            ass.date = obj.date;
            ass.type = obj.type;
            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Notification obj = db.notifications.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}
