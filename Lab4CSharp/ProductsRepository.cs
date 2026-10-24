using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Lab4CSharp
{
    internal class ProductsRepository
    {
        private SQLiteConnection _conn;

        public ProductsRepository()
        {
            _conn = new SQLiteConnection("Data Source=StoreDatabase.db;Version=3;Foreign Keys=True;");
            _conn.Open();
            CreateTable();
        }

        public void CreateDatabase()
        {
            if (!File.Exists("StoreDatabase.db"))
            {

                try
                {
                    SQLiteConnection.CreateFile("StoreDatabase.db");
                }
                catch (SQLiteException e)
                {
                    Trace.WriteLine(DateTime.Now + ": " + e.Message);
                }

            }
        }

        public void CreateTable()
        {
            string query = "CREATE TABLE IF NOT EXISTS Products (" +
                "ProductID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "ProductName TEXT NOT NULL, " +
                "ProductDescription TEXT, " +
                "StoreEntryDate DATETIME NOT NULL, " +
                "ExpirationDate DATETIME NOT NULL, " +
                "Quantity INTEGER NOT NULL, " +
                "CategoryID INTEGER NOT NULL REFERENCES CategoriiProduse(Id))," +
                "CategoryNaem TEXT NOT NULL";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, _conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException e)
            {
                Trace.WriteLine(DateTime.Now + ": " + e.Message);
            }
            
        }

        public void AddProduct(string productName, string productDescription,
            DateTime storeEntryDate, DateTime expirationDate, int quantity, int categoryID)
        {
            string query = "INSERT INTO Products (ProductName,ProductDescription,StoreEntryDate,ExpirationDate,Quantity,CategoryID) VALUES" +
                "(@Name,@Description,@Entry,@Expiration,@Quant,@Category)";
            try
            {
                using (var cmd = new SQLiteCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@Description", productDescription);
                    cmd.Parameters.AddWithValue("@Entry", storeEntryDate);
                    cmd.Parameters.AddWithValue("@Expiration", expirationDate);
                    cmd.Parameters.AddWithValue("@Quant", quantity);
                    cmd.Parameters.AddWithValue("@Category", categoryID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException e)
            {
                Trace.WriteLine(DateTime.Now + ": " + e.Message);
            }
            
        
        }
        public void BuyProduct(int productID, int quantity)
        {
            string query = "UPDATE Products SET Quantity = Quantity + @Quant WHERE ProductID = @Id";
            try
            {
                using (var cmd = new SQLiteCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@Quant", quantity);
                    cmd.Parameters.AddWithValue("@Id", productID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException e)
            {
                Trace.WriteLine(DateTime.Now + ": " + e.Message);
            }
            
        }

        public bool SellProduct(int productID, int quantity)
        {
            string query = "UPDATE Products SET Quantity = Quantity - @Quant " +
                           "WHERE ProductID = @Id AND Quantity >= @Quant";
            using (var cmd = new SQLiteCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@Quant", quantity);
                cmd.Parameters.AddWithValue("@Id", productID);
                int changedRows = cmd.ExecuteNonQuery();
                return changedRows == 1;
            }
        }
        public void ChangeCategory(int productID, int categoryID)
        {
            string query = "UPDATE Products SET CategoryID = @Category WHERE ProductID = @Id";

            using (var cmd = new SQLiteCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@Category", categoryID);
                cmd.Parameters.AddWithValue("@Id", productID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Products> GetProducts(int categoryID = 0)
        {
            string query = "SELECT p.*, c.Denumire AS CategoryName FROM Products p " +
                           "JOIN CategoriiProduse c ON c.Id = p.CategoryID";
            if (categoryID != 0)
                query += " WHERE p.CategoryID = @Category";

            var products = new List<Products>();

            using (var cmd = new SQLiteCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@Category", categoryID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var p = new Products();
                        p.ProductID = Convert.ToInt32(reader["ProductID"]);
                        p.ProductName = reader["ProductName"].ToString();
                        p.ProductDescription = reader["ProductDescription"].ToString();
                        p.StoreEntryDate = Convert.ToDateTime(reader["StoreEntryDate"]);
                        p.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                        p.Quantity = Convert.ToInt32(reader["Quantity"]);
                        p.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                        
                        products.Add(p);
                    }
                }
            }

            return products;
        }

        public void Close()
        {
            _conn.Close();
        }
    }
}
