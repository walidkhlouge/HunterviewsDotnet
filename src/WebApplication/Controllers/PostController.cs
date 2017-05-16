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
    public class PostController : DefaultController
    {
        // GET: Post
        public async Task<ActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "description" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";




            var query = from c in db.posts

                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.description.StartsWith(searchString));

            }
            switch (sortOrder)
            {

                case "description":
                    query = query.OrderByDescending(s => s.description);
                    break;
                case "Date":
                    query = query.OrderBy(s => s.description);
                    break;
                //case "offerid":
                   // query = query.OrderByDescending(s => s.offerid);
                    //break;
                default:
                    query = query.OrderBy(s => s.id);
                    break;
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            {
                Post p = db.posts.Where(c => c.id ==
                  id).SingleOrDefault();


                return View(p);

            }


        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {

            {
                Post p = db.posts.Where(c => c.id ==
                      id).SingleOrDefault();
                db.posts.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // POST: Post/Delete/5
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
    }
}