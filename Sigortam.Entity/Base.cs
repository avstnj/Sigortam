using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.Entity
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool isActive { get; set; }
    }
}
