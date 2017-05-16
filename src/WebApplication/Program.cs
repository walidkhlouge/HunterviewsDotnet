using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using WebApplication.Models;
using System.IO;

namespace WebApplication
{
    public class Program
    {


        public static void Main(string[] args)
        {



            var config = new ConfigurationBuilder()
                    .AddCommandLine(args).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            var host = new WebHostBuilder()
                        .UseKestrel()
                        .UseConfiguration(config)
                        .UseStartup<Startup>()
                        .Build();
            
            host.Run();

        }


    }
}
