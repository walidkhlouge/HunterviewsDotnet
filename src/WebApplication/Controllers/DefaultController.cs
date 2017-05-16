using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        public HunterViewContext db { get; set; }
        public DefaultController()
        {
            this.db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;");
        }
    }
}