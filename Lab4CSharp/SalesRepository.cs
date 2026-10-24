using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class SalesRepository
    {
        public void AddSale(int productID, int quantity)
        {
            using (var db = new StoreDB())
            {
                db.IstoricVanzari.Add(new IstoricVanzari { IdProdus = productID, Cantitate = quantity });
                db.SaveChanges();
            }
        }

        public List<VanzareAfisata> GetSales(List<Products> products)
        {
            using (var db = new StoreDB())
            {
                List<IstoricVanzari> sales = db.IstoricVanzari.ToList();

                var result = new List<VanzareAfisata>();
                foreach (IstoricVanzari sale in sales)
                {
                    Products product = products.FirstOrDefault(p => p.ProductID == sale.IdProdus);
                    if (product != null)
                    {
                        result.Add(new VanzareAfisata
                        {
                            Produs = product.ProductName,
                            Categorie = product.CategoryName,
                            Cantitate = sale.Cantitate
                        });
                    }
                }
                return result;
            }
        }
    }
}
