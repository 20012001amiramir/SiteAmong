using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace GameWebSiteProject.Pages
{
    public class user_profileModel : PageModel
    {
        private readonly IRepository<User> repository;
        public string Avatar { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Nickname { get; set; }
        public string About { get; set; }
        public user_profileModel(IConfiguration configuration)
        {
            this.repository = new UserRepository(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                User user = repository.GetBy("Username", HttpContext.Session.GetString("username"));
                Avatar = user.Avatar;
                Age = GetAge(user.Birthday);
                Sex = user.Sex;
                About = user.About;
                Nickname = user.Nickname;
                return Page();
            }
        }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
        private int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age)) age--;
            return age;
        }
    }
}
