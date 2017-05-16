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
    public class FormationController : Controller
    {
        private HunterViewContext db;

        public FormationController()
        {
            this.db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
);
        }
        // GET: Formation
        public async Task<ActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ecole_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";




            var query = from c in db.formations

                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.ecole.StartsWith(searchString));

            }
            switch (sortOrder)
            {
               
                case "ecole_desc":
                    query = query.OrderByDescending(s => s.ecole);
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

        // GET: Formation/Details/5
        public ActionResult Details(int id)
        {
            {


                Formation obj = db.formations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);


            }
        }

        // GET: Formation/Create
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Formation obj)
        {
            if (ModelState.IsValid)
            {
                
                    db.formations.Add(obj);
                    db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            
                Formation obj = db.formations.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            
        }

        [HttpPost]
        public IActionResult Update(Formation obj)
        {
            if (ModelState.IsValid)
            {
                
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            
                Formation obj = db.formations.Where(c => c.id ==
                   id).SingleOrDefault();
                db.formations.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public IActionResult Participants(int id)
        {
            var query = db.user.Where(u => u.id == id).ToList();
            return View(query);
        }
    }
}