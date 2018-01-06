using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public DomainUser Creator { get; set; }
        public int CreatorId { get; set; }
        public ICollection<Tag> Tag { get; set; }
    }
}