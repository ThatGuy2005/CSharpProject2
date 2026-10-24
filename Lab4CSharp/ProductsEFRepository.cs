using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class ProductsEFRepository
    {
        public void AddProduct(string productName, string productDescription,
            DateTime storeEntryDate, DateTime expirationDate, int quantity, int categoryID)
        {
            using (var db = new StoreDB())
            {
                var product = new Products
                {
                    ProductName = productName,
                    ProductDescription = productDescription,
                    StoreEntryDate = storeEntryDate,
                    ExpirationDate = expirationDate,
                    Quantity = quantity,
                    CategoryID = categoryID
                };

                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        public bool UpdateProduct(int productID, int addedQuantity, int categoryID)
        {
            using (var db = new StoreDB())
            {
                Products product = db.Products.Find(productID);
                if (product == null)
                    return false;

                product.Quantity += addedQuantity;
                if (categoryID != 0)
                    product.CategoryID = categoryID;

                db.SaveChanges();   // EF sees the changes by itself, no need to set the State
                return true;
            }
        }

        public List<ProdusAfisat> GetProducts(int categoryID = 0)
        {
            using (var db = new StoreDB())
            {
                var query = from p in db.Products
                            join c in db.CategoriiProduse on p.CategoryID equals c.Id
                            where categoryID == 0 || p.CategoryID == categoryID
                            select new ProdusAfisat
                            {
                                ProductID = p.ProductID,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                StoreEntryDate = p.StoreEntryDate,
                                ExpirationDate = p.ExpirationDate,
                                Quantity = p.Quantity,
                                CategoryID = p.CategoryID,
                                CategoryName = c.Denumire
                            };

                return query.ToList();
            }
        }

        public Products GetProduct(int productID)
        {
            using (var db = new StoreDB())
            {
                return db.Products.Find(productID);
            }
        }

        // Selling: takes the items out of stock AND writes the sale into IstoricVanzari.
        // Both changes are saved by the same SaveChanges, so either both happen or neither.
        // Returns false if the product doesn't exist or there isn't enough stock.
        public bool SellProduct(int productID, int quantity)
        {
            using (var db = new StoreDB())
            {
                Products product = db.Products.Find(productID);
                if (product == null || quantity <= 0 || product.Quantity < quantity)
                    return false;

                product.Quantity -= quantity;
                db.IstoricVanzari.Add(new IstoricVanzari { IdProdus = productID, Cantitate = quantity });

                db.SaveChanges();
                return true;
            }
        }
    }
}
