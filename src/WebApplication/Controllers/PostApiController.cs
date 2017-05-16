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
    [Route("api/PostApi")]
    public class PostApiController : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {

            var query = from c in db.posts
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Post> Get(int id)
        {

            var query = from c in db.posts
                        orderby c.id ascending
                        where c.id == id
                        select c;
            return query.ToList();

        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody]Post pos)
        {
            db.posts.Add(pos);
            db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Post obj)
        {
            var ass = db.posts.Where(c => c.id == obj.id).SingleOrDefault();
            ass.date = obj.date;
            ass.description = obj.description;
            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Post obj = db.posts.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();
        }
    }
}
