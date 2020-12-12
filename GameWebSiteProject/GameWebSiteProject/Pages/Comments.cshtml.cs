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
        private readonly IRepository<Comment> commentRepository;
        public List<Comment> SortedComments { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public byte[] AuthorAvatar { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string CommentAuthor { get; set; }
        public DateTime DateSent { get; set; }
        public byte[] CommentAuthorAvatar { get; set; }
        public int Likes { get; set; }
        public CommentsModel(IConfiguration configuration)
        {
            this.userRepository = new Repository<User>(configuration);
            this.workRepository = new Repository<PeopleWork>(configuration);
            this.commentRepository = new Repository<Comment>(configuration);

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
                var comments = commentRepository.GetAll();
                SortedComments = comments.OrderBy(x => x.DateSent).ToList();
             
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
        public void GetUser(Guid User_Id)
        {
            User user = userRepository.GetBy("Id", User_Id.ToString());
            CommentAuthor = user.Username;
            CommentAuthorAvatar = user.Avatar;
        }
        public string GetForUser(Guid User_Id)
        {
            return userRepository.GetBy("Id", User_Id.ToString()).Username;
        }
        public string GetWorkname(Guid Work_Id)
        {
            return workRepository.GetBy("Id", Work_Id.ToString()).Name;
        }
    }
}
