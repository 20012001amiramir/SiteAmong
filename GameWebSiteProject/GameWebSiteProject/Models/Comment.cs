using System;

namespace GameWebSiteProject.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public Guid Work_Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public string ForUser { get; set; }
    }
}
