using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameWebSiteProject.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public short Age { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public string About { get; set; }
        
        public User() { }

        public User(string Username, string Password, string Email, short Age)
        {
            this.Username = Username;
            this.Password = ComputeHash(Password, new MD5CryptoServiceProvider());
            this.Email = Email;
            this.Age = Age;
        }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = ComputeHash(Password, new MD5CryptoServiceProvider());
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
