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
                SQLiteConnection.CreateFile("StoreDatabase.db");
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

    }
}
