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
    public class user_profile_editModel : PageModel
    {
        private readonly IRepository<User> repository;
        public byte[] Avatar { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Nickname { get; set; }
        public string About { get; set; }
        public user_profile_editModel(IConfiguration configuration)
        {
            this.repository = new UserRepository(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                User user = repository.GetBy("Id", HttpContext.Session.GetString("id"));
                Avatar = user.Avatar;
                Age = user.Age;
                Sex = user.Sex;
                About = user.About;
                Nickname = user.Nickname;
                return Page();
            }
        }
        public IActionResult OnPostEdit(IFormFile Avatar, string NewNickname, short NewAge, string NewSex, string NewAbout)
        {
            User user = repository.GetBy("Id", HttpContext.Session.GetString("id"));
            byte[] imageData = null;
            if (Avatar != null)
            {
                using (var binaryReader = new BinaryReader(Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Avatar.Length);
                }
                user.Avatar = imageData;
            }
            user.Nickname = NewNickname;
            user.Age = NewAge;
            user.Sex = NewSex;
            user.About = NewAbout;
            repository.Update(user);
            return RedirectToPage("user_profile");
        }
    }
}
