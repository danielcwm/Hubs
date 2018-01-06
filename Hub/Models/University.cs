using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.Models
{
    public class University
    {
        public int Id { get; set; }

        public string UniName { get; set; }

        public string State { get; set; }

        public string CreateBy { get; set; }

        public DateTime DateCreated { get; set; }

        public string Campus { get; set; }

        public ICollection<Unit> Units { get; set; }

        public ICollection<DomainUser> DomainUser { get; set; }
    }
}