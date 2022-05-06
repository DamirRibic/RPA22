using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KlicApija
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }
        static async Task RunAsync()
        {
            HttpClient klient = new HttpClient();
            klient.BaseAddress = new Uri("http://localhost:54245/");
            klient.DefaultRequestHeaders.Accept.Clear();
            klient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage odg = await klient.GetAsync("api/Products");
            if (odg.IsSuccessStatusCode)
            {
                List<Product> plista = await odg.Content.ReadAsAsync<List<Product>>();
                foreach(var p in plista)
                Console.WriteLine("Moj produkt "+p.Ime+" "+p.Kategorija+" "+p.Cena);
            }

        }
    }
}
