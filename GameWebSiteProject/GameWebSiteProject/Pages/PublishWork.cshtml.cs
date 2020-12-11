using System;
using System.Collections.Generic;
using System.IO;
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
    public class PublishWorkModel : PageModel
    {
        private readonly IRepository<PeopleWork> workRepository;
        private readonly IRepository<User> userRepository;
        public PublishWorkModel(IConfiguration configuration)
        {
            this.workRepository = new Repository<PeopleWork>(configuration);
            this.userRepository = new Repository<User>(configuration);
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {        
                return Page();
            }
        }
        public IActionResult OnPostPublish(string Name, string Type, IFormFile image, string Description)
        {            
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)image.Length);
            }

            PeopleWork work = new PeopleWork()
            {
                Id = Guid.NewGuid(),
                User_Id = userRepository.GetBy("Username", HttpContext.Session.GetString("username")).Id,
                Name = Name,
                Description = Description,
                DateSent = DateTime.Now,
                Type = Type,
                Image = imageData
            };

            workRepository.Insert(work);

            return RedirectToPage("user_profile");
        }
    }
}
