using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Seminarska.Data
{
    public class SeminarskaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SeminarskaContext() : base("name=SeminarskaContext")
        {
        }

        public System.Data.Entity.DbSet<Seminarska.Models.Filmi> Filmis { get; set; }

        public System.Data.Entity.DbSet<Seminarska.Models.Igralci> Igralcis { get; set; }

        public System.Data.Entity.DbSet<Seminarska.Models.Režiserji> Režiserji { get; set; }
    }
}
