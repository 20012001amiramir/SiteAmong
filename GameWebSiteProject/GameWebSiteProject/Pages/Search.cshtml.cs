using System;
using System.Collections.Generic;
using System.Linq;
using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace GameWebSiteProject.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<PeopleWork> workRepository;
        public List<PeopleWork> worksResult { get; set; }
        public List<User> usersResult { get; set; }
        public SearchModel(IConfiguration configuration)
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
            else
            {
                return Page();
            }
        }
        public IActionResult OnPostComment(string workname)
        {
            HttpContext.Session.SetString("workname", workname);
            return RedirectToPage("Comments");
        }

        public IActionResult OnPostFind(string text, string type, string sex, string nickname, int agefrom,
                                       int ageto, string posttype, int likesfrom,
                                       int likesto, DateTime fromdate, DateTime todate)
        {
            List<User> users = new List<User>();
            List<PeopleWork> works = new List<PeopleWork>();
            if (type == "All")
            {
                if (nickname != null)
                {
                    users = (List<User>)userRepository.GetAllBy("Username", text, "Nickname", nickname);
                }
                else
                {
                    users = (List<User>)userRepository.GetAllBy("Username", text);
                }

                works = (List<PeopleWork>)workRepository.GetAllBy("Type", posttype);
                usersResult = Filter(users, sex, agefrom, ageto);
                worksResult = Filter(works.Where(x => x.Name.Contains(text)).ToList(), likesfrom, likesto, fromdate, todate);
            }
            if(type == "User")
            {
                if(nickname != null)
                {
                    users = (List<User>)userRepository.GetAllBy("Username", text, "Nickname", nickname);                 
                }
                else
                {
                    users = (List<User>)userRepository.GetAllBy("Username", text);
                }
                
                usersResult = Filter(users, sex, agefrom, ageto);
            }
            if (type == "Post")
            {
                works = (List<PeopleWork>)workRepository.GetAllBy("Type", posttype);
                worksResult = Filter(works, likesfrom, likesto, fromdate, todate);
            }
            return Page();
        }
        private List<User> Filter(List<User> users, string sex, int agefrom, int ageto)
        {           
            return FilterSex(FilterAge(users, agefrom, ageto),sex);
        }
        private List<PeopleWork> Filter(List<PeopleWork> works, int likesfrom, int likesto, DateTime fromdate, DateTime todate)
        {
            return FilterLikes(FilterDate(works, fromdate, todate), likesfrom, likesto);
        }
        private List<User> FilterSex(List<User> users, string sex)
        {
            if (sex != null)
            {
                return users.Where(x => x.Sex == sex).ToList();
            }
            else return users;
        } 
        
        private List<User> FilterAge(List<User> users, int agefrom, int ageto)
        {
            if (agefrom != 0 && ageto == 0)
            {
                return users.Where(x => x.Age >= agefrom).ToList();
            }
            else
            {
                if(agefrom == 0 && ageto != 0)
                {
                    return users.Where(x => x.Age <= ageto).ToList();
                }
                else
                {
                    if (agefrom != 0 && ageto != 0)
                    {
                        return users.Where(x => x.Age >= agefrom && x.Age <= ageto).ToList();
                    }
                    else return users;
                }
            }
        }

        private List<PeopleWork> FilterLikes(List<PeopleWork> works, int likesfrom, int likesto)
        {
            if (likesfrom != 0 && likesto == 0)
            {
                return works.Where(x => x.Likes >= likesfrom).ToList();
            }
            else
            {
                if (likesfrom == 0 && likesto != 0)
                {
                    return works.Where(x => x.Likes <= likesto).ToList();
                }
                else
                {
                    if (likesfrom != 0 && likesto != 0)
                    {
                        return works.Where(x => x.Likes >= likesfrom && x.Likes <= likesto).ToList();
                    }
                    else return works;
                }
            }
        }

        private List<PeopleWork> FilterDate(List<PeopleWork> works, DateTime fromdate, DateTime todate)
        {
            if (fromdate != default && todate == default)
            {
                return works.Where(x => x.DateSent >= fromdate).ToList();
            }
            else
            {
                if (fromdate == default && todate != default)
                {
                    return works.Where(x => x.DateSent <= todate).ToList();
                }
                else
                {
                    if (fromdate != default && todate != default)
                    {
                        return works.Where(x => x.DateSent >= fromdate && x.DateSent <= todate).ToList();
                    }
                    else return works;
                }
            }
        }


    }
}
