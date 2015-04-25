using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<HallContactDetail> HallContactDetails { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
    }
}