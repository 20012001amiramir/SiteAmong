using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebSiteProject.Models
{
    public class PeopleWork
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateSent { get; set; }
        public string Type { get; set; }
        public int Likes { get; set; }
        public byte[] Image { get; set; }
    }
}
