using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class CertificationController : DefaultController
    {

        // GET: Certification
        public async Task<ActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";




            var query = from c in db.certifications

                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.title.StartsWith(searchString));

            }
            switch (sortOrder)
            {

                case "title_desc":
                    query = query.OrderByDescending(s => s.title);
                    break;
                case "Date":
                    query = query.OrderBy(s => s.dateStart);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.dateStart);
                    break;
                default:
                    query = query.OrderBy(s => s.id);
                    break;
            }
            return View(await query.AsNoTracking().ToListAsync());





        }

        // GET: Certification/Details
        public ActionResult Details(int id)
        {
            {


                Certification obj = db.certifications.Where(c => c.id == id).SingleOrDefault();
                return View(obj);


            }
        }

        // GET: Certification/Create
        public ActionResult Create(Certification obj)
        {
            if (ModelState.IsValid)
            {
                    db.certifications.Add(obj);
                    db.SaveChanges();                          
                    return RedirectToAction("Index");
                
            }
            return View(obj);
        }



        [HttpPost]
        public ActionResult Insert(Certification obj)
        {
            if (ModelState.IsValid)
            {
               
                    db.certifications.Add(obj);
                    db.SaveChanges();
                
            }
            return View(obj);
        }
        public ActionResult Edit(int id)
        {
           
                Certification obj = db.certifications.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            
        }

        [HttpPost]
       public ActionResult Edit(Certification obj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        

        // GET: Certification/Delete
        public ActionResult Delete(int id)
        {

                Certification obj = db.certifications.Where(c => c.id ==
                   id).SingleOrDefault();
                db.certifications.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
           
            
        }
        public ActionResult Map(string id)
        {
            var i=0;
            switch (id)
            {

                case "Tunis":
                    i = 1;
                    break;
                case "Sfax":
                    i = 2;
                    break;
                case "Sousse":
                    i = 3;
                    break;
                default:
                    i = 3;
                    break;

            }
            Coordonates obj = db.coordinates.Where(c => c.id ==
                   i).SingleOrDefault();
            double a = obj.lat;
            double b = obj.lon;
            ViewBag.res = a;
            ViewBag.res1 = b;

            return View();
        }
    }
}