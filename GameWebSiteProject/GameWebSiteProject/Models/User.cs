using System;

namespace GameWebSiteProject.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public short Age { get; set; }
        public byte[] Avatar { get; set; }
        public string About { get; set; }
        
    }
}
