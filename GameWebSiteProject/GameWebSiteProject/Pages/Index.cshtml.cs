using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

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
            HttpContext.Session.Remove("id");
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
            
        }
        public void OnPostRegister(IFormFile Avatar, string Username, string Nickname, DateTime Birthday, string Password, string RepeatPassword, string Email)
        {
            if (repository.GetBy("Username", Username) == null)
            {
                if(repository.GetBy("Email", Email) == null)
                {
                    if (RepeatPassword == Password)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(Avatar.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)Avatar.Length);
                        }
                        // установка массива байтов                      
                        User user = new User
                        {
                            Username = Username,
                            Nickname = Nickname,
                            Password = ComputeHash(Password, new MD5CryptoServiceProvider()),
                            Email = Email,
                            Age = GetAge(Birthday),
                            Avatar = imageData
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
        public IActionResult OnPostLogin(string Username, string Password, string RememberMe)
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
                    HttpContext.Session.SetString("id", user_.Id.ToString());
                    if (RememberMe == "on")
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(100)
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
                    return RedirectToPage("home_reg");
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
            return Page();
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
        private short GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age)) age--;
            return (short)age;
        }

    }
}
