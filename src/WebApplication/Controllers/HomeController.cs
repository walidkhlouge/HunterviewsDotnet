using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        private HunterViewContext _context;
        
        
        public HomeController()
        {
            this._context = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"
);           
        }
        
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                this._context.user.Add(user);
                this._context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.email + "is successfully registred.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(User user)
        {
            Ldap ldap = new Ldap(user.login,user.password);
            

           if (ldap.connect())
            {

                System.Diagnostics.Debug.WriteLine("Connected !!!!!!!");
                    HttpContext.Session.SetString("login", user.login);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Login or password is wrong.");
            }
            
    
            return View();
        }

        public ActionResult Welcome()
        {
            
            if (HttpContext.Session.GetString("login") != null)
            {
                ViewBag.login = HttpContext.Session.GetString("login");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        

   

        // GET: /<controller>/
        public IActionResult Index()
        {
            return RedirectToAction("Register") ;
        }
        

    }
}
