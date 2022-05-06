using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrvaMVC.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime Izdano { get; set; }
        public int Tip { get; set; }
        public decimal Cena { get; set; }
    }
}