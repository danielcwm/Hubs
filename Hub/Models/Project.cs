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

        public ICollection<DomainUser> DomainUser { get; set; }

        public ICollection<Tag> Tag { get; set; }

        public int VisitedCount { get; set; }

        public int Liked { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }
    }
}