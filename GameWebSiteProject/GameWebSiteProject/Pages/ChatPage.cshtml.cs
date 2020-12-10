using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameWebSiteProject.Pages
{
    public class ChatPageModel : PageModel
    {
        private readonly IRepository<Message> messageRepository;
        private readonly IRepository<User> userRepository;
        public List<Message> SortedHistory { get; set; }
        public ChatPageModel(IConfiguration configuration)
        {
            this.userRepository = new UserRepository(configuration);
            this.messageRepository = new MessageRepository(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                var records = (List<Message>)messageRepository.GetAll();
                var users = (List<User>)userRepository.GetAll();
                SortedHistory = records.OrderBy(x => x.DateSent).ToList();
                return Page();
            }
        }
        public User GetUser(Guid Id)
        {
            return userRepository.GetBy("Id", Id.ToString());
        }
    }
}
