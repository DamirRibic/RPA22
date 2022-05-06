using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Igralci
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public int Filmiid { get; set; }
        public virtual Filmi Filmi { get; set; }


    }
}