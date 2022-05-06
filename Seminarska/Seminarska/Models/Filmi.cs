using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Filmi
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Žanra { get; set; }
        public int LetoIzdaje { get; set; }
        public int Režiserjiid { get; set; }
        public virtual Režiserji Režiserji { get; set; }



    }
}