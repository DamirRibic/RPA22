using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrviTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities context = new BazaZaVajeEntities();
            //vsi dobavitelji
            var x1 = context.DOBAVITELJ;
            //foreach (var y in x1)
            //{
            //    Console.WriteLine(y.D_IME+" "+y.D_KONTAKT);
            //}
            DateTime datum = DateTime.Parse("20.1.2004");
            var x2 = from a in context.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };
            //foreach (var y in x2)
            //{
            //    Console.WriteLine(y.Opis+" "+y.Cena);
            //}
            DateTime danes = DateTime.Now;
            danes=danes.AddDays(365);
            var x3 = from a in context.PRODUKT
                     select new
                     {
                         Opis = a.P_OPIS,
                         Zaloga = a.P_ZALOGA,
                         MinZaloga = a.P_ZALOGA,
                         Cena = a.P_CENA,
                         Zapadlost = danes
                     };
            //foreach (var y in x3)
            //{
            //    Console.WriteLine(y.Opis + " " + y.Zapadlost);
            //}
            var x4 = from a in context.DOBAVITELJ
                     where a.D_KONTAKT.StartsWith("Smith")
                     select a;
            //foreach(var y in x4)
            //{
            //    Console.WriteLine(y.D_KONTAKT);
            //}
            var x5 = (from a in context.PRODUKT
                     select a.D_KODA).Distinct();
            //foreach(var y in x5)
            //{
            //    Console.WriteLine(y);
            //}
            var x6 = context.DOBAVITELJ.Where(e => !x5.Any(p => p == e.D_KODA));
            //foreach (var y in x6)
            //{
            //    Console.WriteLine(y.D_KODA);
            //}
            var x7 = context.KUPEC.Sum(e => e.KUP_STANJE);
            var x8 = (from a in context.KUPEC
                      select a.KUP_STANJE).Sum();
            //Console.WriteLine("prvi rezultat "+x7);
            //Console.WriteLine("drugi rezultat " + x8);

            //            izberi P_OPIS, P_ZALOGA, P_MIN, P_CENA iz tabele PRODUKT, kjer je P_CENA manjša od 50 in
            //            je P_DATUM večji kot 15.jan. 2004
            DateTime datum1 = DateTime.Parse("15.1.2004");
            var x9 = from a in context.PRODUKT
                     where a.P_CENA < 50 
                     where a.P_DATUM < datum1
                     select a;
            //foreach (var y in x9)
            //{
            //    Console.WriteLine(y.P_OPIS + " ",y.P_ZALOGA+" ",y.P_MIN+" ",y.P_CENA+" ");
            //}

            //e.izberi vse dobavitelje, kjer je zaloga v produktu manjša od dvakratnika minimalne zaloge
            var x10 = from a in context.PRODUKT
                      where a.P_ZALOGA < 2 * a.P_MIN
                      select a;
            foreach (var y in x10)
            {
                Console.WriteLine(y.DOBAVITELJ+" ");
            }


            Console.ReadLine();
        }
    }
}
