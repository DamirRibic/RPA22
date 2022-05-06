using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Filmi
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Žanra { get; set; }
        public int LetoIzdaje { get; set; }
    }
}