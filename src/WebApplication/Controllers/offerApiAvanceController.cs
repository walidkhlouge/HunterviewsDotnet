﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class offerApiAvanceController : DefaultController
    {
        // GET: api/values
        [HttpGet("{msg}")]
        public IEnumerable<Offer> Get(string msg)
        {

            var offrs = from a in db.offers
                        where a.description.StartsWith(msg)
                        select a
                          ;
            return offrs.ToList();

        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Offer> statusOffre(int id)
        {

            var query = from c in db.offers
                        orderby c.id ascending
                        where (c.id == id) && (c.state == true)
                        select c;
            return query.ToList();

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
