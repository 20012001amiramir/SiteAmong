using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace GameWebSiteProject.Pages
{
    public class home_regModel : PageModel
    {
        private readonly IRepository<User> repository;
        public string Username { get; set; }
        public home_regModel(IConfiguration configuration)
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
                Username = user.Username;
                return Page();

            } 
        }
    }
}
