using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace GameWebSiteProject.Pages
{
    public class user_profileModel : PageModel
    {
        private readonly IRepository<User> repository;
        public byte[] Avatar { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Nickname { get; set; }
        public string About { get; set; }
        public user_profileModel(IConfiguration configuration)
        {
            this.repository = new Repository<User>(configuration);
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
    }
}
