using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public static class HunterViewContextFactory
    {
        public static HunterViewContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HunterViewContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new HunterViewContext(optionsBuilder.Options);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
