using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using GameWebSiteProject.CommandMaker;
using GameWebSiteProject.Models;

namespace GameWebSiteProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Username = "Maksim";
            InsertCommandMaker.Create(user);
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
