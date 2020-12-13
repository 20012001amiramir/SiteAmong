using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace GameWebSiteProject.Pages
{
    public class MyWorksModel : PageModel
    {
        public List<PeopleWork> Yourworks { get; set; }
        private readonly IRepository<PeopleWork> worksRepository;
        private readonly IRepository<User> usersRepository;
        public int Count { get; set; }
        public MyWorksModel(IConfiguration configuration)
        {
            this.worksRepository = new Repository<PeopleWork>(configuration);
            this.usersRepository = new Repository<User>(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                var works = (List<PeopleWork>)worksRepository.GetAll();
                Yourworks = works.OrderByDescending(x => x.DateSent).ToList(); 
                return Page();
            }
        }
        public Guid GetUserId(string Username)
        {
            return usersRepository.GetBy("Username", Username).Id;
        }
        public IActionResult OnPostDelete(string workname)
        {
            worksRepository.Delete("Name", workname);
            return RedirectToPage("MyWorks");
        }
    }
}
