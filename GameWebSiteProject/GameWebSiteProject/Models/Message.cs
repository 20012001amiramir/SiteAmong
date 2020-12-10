using System;

namespace GameWebSiteProject.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        
    }
}
