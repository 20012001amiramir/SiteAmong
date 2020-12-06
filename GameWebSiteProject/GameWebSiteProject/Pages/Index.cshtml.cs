using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;

namespace GameWebSiteProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<User> repository;
        public string UsernameValid { get; set; }
        public string PasswordValid { get; set; }
        public string FieldsValid { get; set; }
        public string LoginValid { get; set; }
        public IndexModel(IConfiguration configuration)
        {
            this.repository = new UserRepository(configuration);
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("Index");
        }
        public void OnPostRegister(string Username, short Age, string Password, string RepeatPassword, string Email)
        {
            if (repository.GetByIdentfrs(Username) == null)
            {
                if (RepeatPassword == Password)
                {
                    User user = new User(Username, Password, Email, Age);
                    repository.Insert(user);
                }
                else
                {
                    PasswordValid = "Passwords are not equal";
                }
            }
            else
            {
                UsernameValid = "This username is already used";
            }
        }
        public void OnPostLogin(string Username, string Password, string RememberMe)
        {
            User user_ = repository.GetByIdentfrs(Username);
            if (user_ != null)
            {
                User user = new User(Username, Password);
                if (user.Password == user_.Password)
                {
                    if (RememberMe == "on")
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(10)
                        };
                        Response.Cookies.Append("Username", Username, cookieOptions);
                        Response.Cookies.Append("Password", Password, cookieOptions);
                    }
                    HttpContext.Session.SetString("username", Username);
                }
                else
                {
                    LoginValid = "Your username or password are wrong. Try again";
                }
            }
            else
            {
                LoginValid = "Your username or password are wrong. Try again";
            }
        }
       
    }
}
