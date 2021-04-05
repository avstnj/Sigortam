using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.Entity
{
    public class Customer : Base
    {
        public string Plaka { get; set; }
        public string TCKN { get; set; }
        public string RuhsatSeriKodu { get; set; }
        public int RuhsatSeriNo { get; set; }
    }
}
