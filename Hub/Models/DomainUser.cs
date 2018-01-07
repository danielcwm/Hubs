using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.Models
{
    public class DomainUser
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<University> University { get; set; }
    }
}