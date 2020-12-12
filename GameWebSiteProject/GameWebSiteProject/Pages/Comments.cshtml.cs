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
    public class CommentsModel : PageModel
    {
        public PeopleWork Works { get; set; }

        private readonly IRepository<PeopleWork> workRepository;
        private readonly IRepository<User> userRepository;
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public byte[] AuthorAvatar { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateSent { get; set; }
        public int Likes { get; set; }
        public CommentsModel(IConfiguration configuration)
        {
            this.userRepository = new Repository<User>(configuration);
            this.workRepository = new Repository<PeopleWork>(configuration);

        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            if (HttpContext.Session.GetString("workname") == null) return RedirectToPage("CommunityWorks");
            else
            {
                PeopleWork work = workRepository.GetBy("Name", HttpContext.Session.GetString("workname"));
                User author = userRepository.GetBy("Id", work.User_Id.ToString());
                Image = work.Image;
                Name = work.Name;
                AuthorName = author.Username;
                AuthorAvatar = author.Avatar;
                Type = work.Type;
                Description = work.Description;
                DateSent = work.DateSent;
                Likes = work.Likes;
                return Page();
            }
        }

    }
}
