using Prodajalna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prodajalna.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] p = new Product[]
        {
            new Product{Id=1,Ime="Paradižnikova juga",Kategorija="jestvine",Cena=1},
            new Product{Id=2,Ime="They/Them Pussy",Kategorija="Eldritch horror",Cena=5},
            new Product{Id=3,Ime="Žoga",Kategorija="igrače",Cena=5}
        };
        public IEnumerable<Product> GetProducts()
        {
            return p;
        }
        public Product GetProduct(int id)
        {
            var produkt = p.Where(a => a.Id == id).FirstOrDefault();
            return produkt;
        }
    }
}
