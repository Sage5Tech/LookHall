using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class HallTypeRelation
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int TypeId { get; set; }

        public virtual Hall Hall { get; set; }
        public virtual HallType Type { get; set; }


    }
}