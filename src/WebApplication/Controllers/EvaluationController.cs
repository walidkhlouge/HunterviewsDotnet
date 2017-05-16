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
    public class EvaluationController : Controller
    {

        // GET: Offer
        public ActionResult Index()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {

                var query = from c in db.evaluations
                            orderby c.id ascending
                            select c;
                return View(query.ToList());
            }
        }

        [HttpPost]
        public ActionResult Index(int SearchString)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Console.Write(db);

                var eval = from a in db.evaluations
                            where a.mark.Equals(SearchString)
                            select a
                            ;
                Console.Write(eval);
                return View(eval.ToList());
            }
        }



        // GET: Offer
        public ActionResult IndexW()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {

                var query = from c in db.evaluations
                            orderby c.id ascending
                            select c;
                return View(query.ToList());
            }
        }

        [HttpPost]
        public ActionResult IndexW(int SearchString)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Console.Write(db);

                var eval = from a in db.evaluations
                            where a.mark.Equals(SearchString)
                            select a
                            ;
                Console.Write(eval);
                return View(eval.ToList());
            }
        }




        [HttpGet]
        public ActionResult Details(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Evaluation obj = db.evaluations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }


        // GET: Offer/Details/5
        public ActionResult Details(Evaluation obj)
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
        public ActionResult Create(Evaluation eval)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    db.evaluations.Add(eval);
                    db.SaveChanges();
                }
            }
            return View(eval);
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
            {
                Evaluation obj = db.evaluations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }

        // POST: Offer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evaluation obj)
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
                Evaluation obj = db.evaluations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }


        [HttpPost]
        public IActionResult Update(Evaluation obj)
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
        public ActionResult Delete(int id, Evaluation obj)
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
                Evaluation obj = db.evaluations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccptEval(Evaluation obj, int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
 ))
                {
                    Evaluation ob = db.evaluations.Where(c => c.id == id).SingleOrDefault();

                    ob.mark = obj.mark+1;
                    db.Entry(ob);
                    db.SaveChanges();
                    return RedirectToAction("Index");



                }
            }
            return View(obj);

        }






    }


}