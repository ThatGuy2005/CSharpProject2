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
    }
}
