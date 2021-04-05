using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sigortam.Entity
{
    public class Bid : Base
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string BidDescription { get; set; }
        public Double BidAmount { get; set; }
        public int CustomerId { get; set; } 

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
