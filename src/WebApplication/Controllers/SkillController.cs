using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Service;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class SkillController : DefaultController
    {
        SkillService sk = new SkillService();
        // GET: Skill

        /*  public ActionResult Index(string SearchString)
          {
              {

                  {

                      var query = from c in db.skills
                                  where c.name.StartsWith(SearchString)

                                  select c;
                      return View(query.ToList());
                  }
              }

          }*/

        public async Task<ActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "category" : "";
            ViewData["DateSortParm"] = sortOrder == "Name" ? "name" : "Name";




            var query = from c in db.skills

                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.name.StartsWith(searchString));

            }
            switch (sortOrder)
            {

                case "category":
                    query = query.OrderByDescending(s => s.category);
                    break;
                case "Name":
                    query = query.OrderBy(s => s.name);
                    break;
                case "name":
                    query = query.OrderByDescending(s => s.name);
                    break;
                default:
                    query = query.OrderBy(s => s.id);
                    break;
            }
            return View(await query.AsNoTracking().ToListAsync());





        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            {
                Skill sk = db.skills.Where(c => c.id ==
                  id).SingleOrDefault();


                return View(sk);

            }

               
        }

        // GET: Skill/Create
        public ActionResult Create(Skill sk)
        {
            if (ModelState.IsValid)
            {
                {
                    db.skills.Add(sk);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(sk);
      
        }

        // POST: Skill/Create
/*       [HttpPost]
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
*/
        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
            {
                Skill sk = db.skills.Where(c => c.id == id).SingleOrDefault();
                return View(sk);
            }
            
        }

        // POST: Skill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skill sk)
        {
            if (ModelState.IsValid)
            {
                {
                    db.Entry(sk).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View(sk);
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {

            {
                Skill sk = db.skills.Where(c => c.id ==
                      id).SingleOrDefault();
                db.skills.Remove(sk);
                db.SaveChanges();
             return   RedirectToAction("Index");
            }
            }

        // POST: Skill/Delete/5
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

        public ActionResult Statistics()
        {
            {
                int a = sk.StatisticSkillDesktop();
                int b = sk.StatisticSkillWeb();
                int c = sk.StatisticSkillMobile();
                ViewBag.res = a;
               
                ViewBag.res1 = b;
                ViewBag.res2 = c;

                return View();
            }
        }
    }
}