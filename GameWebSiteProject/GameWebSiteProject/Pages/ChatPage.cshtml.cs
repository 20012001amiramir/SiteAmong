using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
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
        public byte[] Avatar { get; set; }
        public string Username { get; set; }
        public List<Message> SortedHistory { get; set; }
        public ChatPageModel(IConfiguration configuration)
        {
            this.userRepository = new Repository<User>(configuration);
            this.messageRepository = new Repository<Message>(configuration);
        }
        public IActionResult OnGet()
        {
            var records = (List<Message>)messageRepository.GetAll();
            SortedHistory = records.OrderBy(x => x.DateSent).ToList();
            return Page();
        }
        public IActionResult OnPostDeleteMessage(Guid Id)
        {
            messageRepository.Delete("Id", Id.ToString());
            return RedirectToPage("ChatPage");
        }
        public void GetUser(Guid User_Id)
        {
            User user = userRepository.GetBy("Id", User_Id.ToString());
            Username = user.Username;
            Avatar = user.Avatar;
        }
    }
}
