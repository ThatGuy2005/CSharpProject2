using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class StoreDB : DbContext
    {
        public StoreDB() : base(@"name=StoreDb") { }
        public DbSet<Products> Products { get; set; }
    }
}
