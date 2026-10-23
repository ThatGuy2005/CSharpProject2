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
        public void CreateDatabaseIfNotFound()
        {
            if(!File.Exists("StoreDatabase.db"))
            {
                Task.Run(() =>
                {
                    try
                    {
                        SQLiteConnection.CreateFile("StoreDatabase.db");
                    }
                    catch (SQLiteException e)
                    {
                        Trace.WriteLine(DateTime.Now + ": " + e.Message);
                    }
                });
                
            }
        }

        public void CreateTable()
        {
            string query = "CREATE TABLE Products (ProductID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "ProductName TEXT NOT NULL, ProductDescription TEXT, " +
                "StoreEntryDate DATETIME NOT NULL, " +
                "ExpirationDate DATETIME NOT NULL, " +
                "Quantity INTEGER NOT NULL, " +
                "CategoryID INTEGER NOT NULL REFERENCES ProductCategories(CategoryID)";
            Task.Run(() =>
            {
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
            });
        }

        public void AddProduct(string productName,
            DateTime storeEntryDate, DateTime expirationDate,
            int quantity, int categoryID)
        {
            string query = "INSERT INTO Products (ProductName,StoreEntryDate,ExpirationDate,Quantity,CategoryID) VALUES" +
                "(@Name,@Entry,@Expiration,@Quant,@Category)";
            Task.Run(() =>
            {
                using (var cmd = new SQLiteCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@Entry", storeEntryDate);
                    cmd.Parameters.AddWithValue("@Expiration", expirationDate);
                    cmd.Parameters.AddWithValue("@Quant", quantity);
                    cmd.Parameters.AddWithValue("@Category", categoryID);
                    cmd.ExecuteNonQuery();
                }
            });
        }

    }
}
