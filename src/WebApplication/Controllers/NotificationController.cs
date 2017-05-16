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
    public class NotificationController : Controller
    {

        private HunterViewContext _context;

        public NotificationController()
        {
            this._context = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
);        }

       






        // GET: Notification
        public ActionResult Index()
        {
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
))
                {

                    var query = from c in db.notifications
                                orderby c.id ascending
                                select c;
                    return View(query.ToList());
                }
            }
        }


        //Service Avancé

            public ActionResult ListNotificationPersonnalise()
        {
            List<Notification> listToReturn = new List<Notification>();

            IEnumerable<Notification> listNotificationComplete = this._context.notifications.ToList();
            foreach (var item in listNotificationComplete)
            {
              //  if (!item.seen)
                    listToReturn.Add(item);
                }

            return View(listToReturn);
         }

        public ActionResult ListNotificationPersonnaliseDateYear()
        {
            List<Notification> listToReturn = new List<Notification>();
            IEnumerable<Notification> listNotificationComplete = this._context.notifications.ToList();
            DateTime dateToSearch = DateTime.Now;

            //foreach (var item in listNotificationComplete)
            //{
            //    if (item.date.Year == dateToSearch.Year)
            //        listToReturn.Add(item);
            //}
            return View(listToReturn);
        }
        
        public ActionResult ListNotificationPersonnaliseLogin()
        {

            string loginTest = "james";
            List<Notification> listToReturn = new List<Notification>();
            IEnumerable<Notification> listNotificationComplete = this._context.notifications.ToList();


            foreach (var item in listNotificationComplete)
            {
              // if (item.userid == 3)
                {
                    listToReturn.Add(item);
                }
            }
            return View(listToReturn);

        }





        /*
         * 
         * 
        public IEnumerable<Event> GetListEventWithDate(DateTime dateToSearch)
        {
            List<Event> listToReturn = new List<Event>();
            IEnumerable<Event> listEventComplete = utOfWork.getRepository<Event>().GetMany();

            foreach (var Event in listEventComplete)
            {
                if (Event.DateEvent == dateToSearch)
                {
                    listToReturn.Add(Event);
                }
            }

            return listToReturn;
        }
         */









        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public IActionResult Insert()
        {
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        public IActionResult Insert(Notification obj)
        {
            if (ModelState.IsValid)
            {
                using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
))
                {
                    db.notifications.Add(obj);
                    db.SaveChanges();
                }
            }
            return View(obj);
        }



        public IActionResult Update(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
))
            {
                Notification obj = db.notifications.Where(c => c.id == id).SingleOrDefault();
                return View(obj);
            }
        }

        // POST: Notification/Edit/5
        [HttpPost]
        public IActionResult Update(Notification obj)
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

        // GET: Notification/Delete/5

        public ActionResult Delete(int id)
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
))
            {
                Notification obj = db.notifications.Where(c => c.id ==
                   id).SingleOrDefault();
                db.notifications.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}