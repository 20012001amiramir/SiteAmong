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
    public class CommunityWorksModel : PageModel
    {
        public List<PeopleWork> Works { get; set; }
        private readonly IRepository<PeopleWork> worksRepository;
        private readonly IRepository<User> userRepository;
        public byte[] Avatar { get; set; }
        public string Username { get; set; }
        public CommunityWorksModel(IConfiguration configuration)
        {
            this.userRepository = new Repository<User>(configuration);
            this.worksRepository = new Repository<PeopleWork>(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                var records = (List<PeopleWork>)worksRepository.GetAll();
                Works = records.OrderByDescending(x => x.DateSent).ToList();
                return Page();
            }
        }
        public string GetAuthorUsername(Guid User_Id)
        {
            return userRepository.GetBy("Id", User_Id.ToString()).Username;
        }
        public byte[] GetAuthorAvatar(Guid User_Id)
        {
            return userRepository.GetBy("Id", User_Id.ToString()).Avatar;
        }
    }
}
