using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Hall> Hall { get; set; }
    }
}
