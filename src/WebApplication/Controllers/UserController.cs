using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller

    {
        private HunterViewContext db;
        public UserController()
        {
            this.db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
);
        }
        public async Task<ActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "login" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";




            var query = from c in db.user

                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.login.StartsWith(searchString));

            }
            switch (sortOrder)
            {

                case "login":
                    query = query.OrderByDescending(s => s.login);
                    break;
                case "Date":
                    query = query.OrderBy(s => s.dateCreationAccount);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.dateCreationAccount);
                    break;
                default:
                    query = query.OrderBy(s => s.id);
                    break;
            }
            return View(await query.AsNoTracking().ToListAsync());





        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            


                User obj = db.user.Where(c => c.id == id).SingleOrDefault();
                return View(obj);

            }
        

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(User obj)
        {
            if (ModelState.IsValid)
            {

                db.user.Add(obj);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Update(int id)
        {

            User obj = db.user.Where(c => c.id == id).SingleOrDefault();
            return View(obj);
            

        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User obj)
        {
            if (ModelState.IsValid)
            {

                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();

            }
            return View(obj);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {

            User obj = db.user.Where(c => c.id ==
               id).SingleOrDefault();
            db.user.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Block(int id)
        {

            User obj = db.user.Where(c => c.id ==
                id).SingleOrDefault();
            obj.stateAccount = 0;
            db.user.Update(obj);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        

    }
}