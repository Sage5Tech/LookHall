using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Models
{
    public class HallType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Hall> Hall { get; set; }
    }
}
