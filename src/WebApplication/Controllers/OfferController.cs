using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication.Controllers
{
    public class OfferController : Controller
    {

        // GET: Offer
        public ActionResult Index()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {

                var query = from c in db.offers
                            orderby c.id ascending
                            select c;
                return View(query.ToList());
            }
        }

        [HttpPost]
        public ActionResult Index(string SearchString)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Console.Write(db);

                var offrs = from a in db.offers
                            where a.description.StartsWith(SearchString)
                            select a
                            ;
                Console.Write(offrs);
                return View(offrs.ToList());
            }
        }



        // GET: Offer
        public ActionResult IndexW()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {

                var query = from c in db.offers
                            orderby c.id ascending
                            select c;
                return View(query.ToList());
            }
        }

        [HttpPost]
        public ActionResult IndexW(string SearchString)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Console.Write(db);

                var offrs = from a in db.offers
                            where a.description.StartsWith(SearchString)
                            select a
                            ;
                Console.Write(offrs);
                return View(offrs.ToList());
            }
        }




        [HttpGet]
        public ActionResult Details(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Offer obj = db.offers.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }


        // GET: Offer/Details/5
        public ActionResult Details(Offer obj)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                db.Entry(obj);

            }
            return View(obj);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Offer off)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    db.offers.Add(off);
                    db.SaveChanges();
                }
            }
            return View(off);
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Offer obj = db.offers.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }

        // POST: Offer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Offer obj)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View(obj);

        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Offer obj = db.offers.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }


        [HttpPost]
        public IActionResult Update(Offer obj)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View(obj);
        }



        // POST: Offer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Offer obj)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {

                    db.Remove(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return View(obj);

        }



        public ActionResult Activer(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Offer obj = db.offers.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activer(Offer obj, int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    Offer ob = db.offers.Where(c => c.id == id).SingleOrDefault();

                    ob.state = true;
                    db.Entry(ob);
                    db.SaveChanges();
                    return RedirectToAction("Index");



                }
            }
            return View(obj);

        }






    }


}