using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class ProdusAfisat
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime StoreEntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class VanzareAfisata
    {
        public string Produs { get; set; }
        public string Categorie { get; set; }
        public int Cantitate { get; set; }
    }
}
