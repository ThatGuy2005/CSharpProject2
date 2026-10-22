using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CSharp
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void add_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new StoreDB())
                {
                    try
                    {
                        var product = new Products
                        {
                            //ProductID = int.Parse(productID.Text),
                            ProductName = productName.Text,
                            ProductDescription = productDescription.Text,
                            StoreEntryDate = arrivalDate.Value,
                            ExpirationDate = expirationDate.Value,
                            Quantity = int.Parse(quantity.Text)
                        };
                        db.Products.Add(product);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Product added successfully!");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid input format. Please check your entries.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the product: {ex.Message}");
            }
        }
    }
}
