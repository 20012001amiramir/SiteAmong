using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;
using System.Text;

namespace GameWebSiteProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<User> repository;
        public string UsernameValid { get; set; }
        public string EmailValid { get; set; }
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
        public void OnGet()
        {
            
        }
        public void OnPostRegister(string Username, DateTime Birthday, string Password, string RepeatPassword, string Email)
        {
            if (repository.GetBy("Username", Username) == null)
            {
                if(repository.GetBy("Email", Email) == null)
                {
                    if (RepeatPassword == Password)
                    {
                        User user = new User
                        {
                            Username = Username,
                            Password = ComputeHash(Password, new MD5CryptoServiceProvider()),
                            Email = Email,
                            Birthday = Birthday
                        };
                        repository.Insert(user);
                    }
                    else
                    {
                        PasswordValid = "Passwords are not equal";
                    }
                }
                else
                {
                    EmailValid = "This e-mail is already used";
                }             
            }
            else
            {
                UsernameValid = "This username is already used";
            }
        }
        public void OnPostLogin(string Username, string Password, string RememberMe)
        {
            User user_ = repository.GetBy("Username",Username);
            if (user_ != null)
            {
                User user = new User
                {
                    Username = Username,
                    Password = ComputeHash(Password, new MD5CryptoServiceProvider())
                };
                if (user.Password == user_.Password)
                {
                    HttpContext.Session.SetString("username", Username);
                    if (RememberMe == "on")
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(1)
                        };
                        Response.Cookies.Append("Username", Username, cookieOptions);
                        Response.Cookies.Append("Password", Password, cookieOptions);
                    }
                    else
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(-1)
                        };
                        Response.Cookies.Append("Username", Username, cookieOptions);
                        Response.Cookies.Append("Password", Password, cookieOptions);
                    }
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
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

    }
}
