using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Infrastructure;
using WebApplication.Models;
using WebApplication.ServicePattern;

namespace WebApplication.Service
{
    public class SkillService : Service<Skill>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uw = new UnitOfWork(dbf);
        public SkillService() : base(uw)
        {
        }
        public int StatisticSkillDesktop()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"))
            {
                var results = from g in db.skills
                              where g.category.Equals(Category.Desktop)
                              select g;
                return results.Count();
            }
        }
        public int StatisticSkillWeb()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"))
            {
                var results = from g in db.skills
                              where g.category.Equals(Category.Web)
                              select g;
                return results.Count();
            }
        }
        public int StatisticSkillMobile()
        {
            using (var db = HunterViewContextFactory.Create("server=103.194.48.97;userid=root;pwd=root;port=3306;database=Ang;sslmode=none;"))
            {
                var results = from g in db.skills
                              where g.category.Equals(Category.Mobile)
                              select g;
                return results.Count();
            }

        }



    }
}
