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
    public class userApi : DefaultController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {

            var query = from c in db.user
                        orderby c.id ascending
                        select c;
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<User> Get(int id)
        {
            var query = from c in db.user
                        orderby c.id ascending
                        where c.id == id
                        select c;
            return query.ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User usr)
        {
            db.user.Add(usr);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User usr)
        {
            var ass = db.user.Where(c => c.id == usr.id).SingleOrDefault();
            ass.firstName = usr.firstName;
            ass.lastName = usr.lastName;
            ass.birthDate = usr.birthDate;
            ass.login = usr.login;
            ass.password = usr.password;
            ass.confirmPassword = usr.confirmPassword;
            ass.email = usr.email;
            ass.dateCreationAccount = usr.dateCreationAccount;
            ass.image = usr.image;
            ass.stateAccount = usr.stateAccount;
            ass.street = usr.street;
            ass.city = usr.city;
            ass.state = usr.state;
            ass.postalCode = usr.postalCode;


            db.Entry(ass).State = EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User obj = db.user.Where(c => c.id == id).SingleOrDefault();
            db.Remove(obj);
            db.SaveChanges();

        }
    }
}