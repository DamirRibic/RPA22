using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Igralec
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public int Filmid { get; set; }
        public virtual Film Film { get; set; }


    }
}