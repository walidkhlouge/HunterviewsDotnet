//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication.Models;
//using MimeKit;
//using MailKit.Net.Smtp;

//namespace WebApplication.Controllers
//{
//    public class NewsletterController : Controller
//    {
//        private HunterViewContext db;

//        public NewsletterController()
//        {
//            this.db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
   // "DefaultConnection": "server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;");

//        }
//        // GET: Newsletter
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: Newsletter/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Newsletter/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Newsletter/Create
//        [HttpPost]
        
//        public ActionResult Create(Newsmail obj)
//        {
//            if (ModelState.IsValid)
//            {
//                var message = new MimeMessage();
//                message.From.Add(new MailboxAddress(obj.from));
                
//                    message.Subject = "Sujet:" + obj.subject;
//                    var bodyBuilder = new BodyBuilder();
//                    bodyBuilder.HtmlBody = obj.messag;
//                    message.Body = bodyBuilder.ToMessageBody();

//                    using (var client = new SmtpClient())
//                    {
//                        client.Connect("smtp.sendgrid.net", 587, false);
//                    client.Authenticate("walidkh", "Lappep123");
//                    string[] split = obj.to.Split(',');
//                    foreach (string item in split)
//                    {
//                        message.To.Add(new MailboxAddress(item));
                        
//                        client.Send(message);
                        
//                    }
//                    client.Disconnect(true);
//                }


//            }
//            return View();
//        }
//        public ActionResult Toall(Newsmail obj)
//        {
//            if (ModelState.IsValid)
//            {
//                var query = from c in db.user

//                            select c.email;
//                var message = new MimeMessage();
//                message.From.Add(new MailboxAddress(obj.from));
               
//                foreach (string item in query)
//                {
//                    message.To.Add(new MailboxAddress(item));
//                    message.Subject = "Sujet:" + obj.subject;
//                    var bodyBuilder = new BodyBuilder();
//                    bodyBuilder.HtmlBody = obj.messag;
//                    message.Body = bodyBuilder.ToMessageBody();

//                    using (var client = new SmtpClient())
//                    {
//                        client.Connect("smtp.sendgrid.net", 587, false);

//                        client.Authenticate("walidkh", "Lappep123");
//                        client.Send(message);
//                        client.Disconnect(true);
//                    }
//                }


//            }
//            return View();
//        }

//        // GET: Newsletter/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Newsletter/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Newsletter/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Newsletter/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}