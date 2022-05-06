using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Film
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Žanra { get; set; }
        public int LetoIzdaje { get; set; }
        public int Režiserid { get; set; }
        public virtual Režiser Režiser { get; set; }



    }
}