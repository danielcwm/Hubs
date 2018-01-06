using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CreateBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string Campus { get; set; }

        public ICollection<Unit> Units { get; set; }
        public int UnitId { get; set; }

        public ICollection<DomainUser> DomainUser { get; set; }
    }
}